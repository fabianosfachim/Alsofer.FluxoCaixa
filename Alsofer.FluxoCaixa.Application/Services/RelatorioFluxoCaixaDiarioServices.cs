using Alsofer.FluxoCaixa.Application.Services.Interfaces;
using Alsofer.FluxoCaixa.Application.Services.Wrappers;
using Alsofer.FluxoCaixa.Domain.Model;


namespace Alsofer.FluxoCaixa.Application
{
    public class RelatorioFluxoCaixaDiarioServices : IRelatorioFluxoCaixaDiarioServices
    {
        private readonly IContasPagarServices _contasPagarServices;
        private readonly IContasReceberServices _contasReceberServices;

        public RelatorioFluxoCaixaDiarioServices(IContasPagarServices contasPagarServices, IContasReceberServices contasReceberServices)
        {
            _contasPagarServices = contasPagarServices;
            _contasReceberServices = contasReceberServices;
        }

        public async Task<Response<RelatorioFluxoCaixaDiarioResponse>> GetRelatorioDiarioFluxoCaixa(RelatorioFluxoCaixaDiarioRequest clienteRequest)
        {
            RelatorioFluxoCaixaDiarioResponse relatorioResponse = new RelatorioFluxoCaixaDiarioResponse();
            List<RelatorioFluxoCaixaDiario> relatorioFluxoCaixaDiario = new List<RelatorioFluxoCaixaDiario>();
            
            decimal despesa = 0;
            decimal receita = 0;
            decimal contasPagar = 0;
            decimal contasReceber = 0;

            decimal despesaAux = 0;
            decimal receitaAux = 0;
            decimal contasPagarAux = 0;
            decimal contasReceberAux = 0;

            try
            {
                int qdtDiasMes = getQuantidadeDiasMes(clienteRequest.dataConsulta);
            
                for (int i = 1; i <= qdtDiasMes; i++)
                {
                    DateTime dataConsulta = getDataMes(clienteRequest.dataConsulta, i);

                    despesaAux = 0;
                    receitaAux = 0;
                    contasPagarAux = 0;
                    contasReceberAux = 0;

                    //Dados de Conta a Pagar
                    var lstContasPagar = await _contasPagarServices.ListarContasPagar(dataConsulta);

                    if(lstContasPagar.Data.ContasPagar != null)
                    {
                        if (lstContasPagar.Data.ContasPagar.Any())
                        {
                            foreach (var contaPagar in lstContasPagar.Data.ContasPagar)
                            {
                                if (contaPagar.idStatus == 1)
                                {
                                    despesaAux += contaPagar.vlPagamento.Value;
                                }
                                else if (contaPagar.idStatus == 2)
                                {
                                    contasPagarAux += contaPagar.vlPagamento.Value;
                                }
                            }
                        }
                    }
                    
                    //Dados de Contas a Receber
                    var lstContasReceber = await _contasReceberServices.ListarContasReceber(dataConsulta);

                    if(lstContasReceber.Data.ContasReceber != null)
                    {
                        if (lstContasReceber.Data.ContasReceber.Any())
                        {
                            foreach (var contaReceber in lstContasReceber.Data.ContasReceber)
                            {
                                if (contaReceber.idStatus == 1)
                                {
                                    receitaAux += contaReceber.vlPagamento.Value;
                                }
                                if (contaReceber.idStatus == 2)
                                {
                                    contasReceberAux += contaReceber.vlPagamento.Value;
                                }
                            }
                        }
                    }
                    
                    //Adicionar o valores na variável de entrada
                    RelatorioFluxoCaixaDiario relatorio = new RelatorioFluxoCaixaDiario();

                    relatorio.dia = i;
                    relatorio.despesa = despesaAux;
                    relatorio.receita = receitaAux;
                    relatorio.contasPagar = contasPagarAux;
                    relatorio.contasReceber = contasReceberAux;
                    relatorio.saldoDia = (relatorio.receita - relatorio.despesa);

                    relatorioFluxoCaixaDiario.Add(relatorio);
                }

                despesaAux = 0;
                receitaAux = 0;
                contasPagarAux = 0;
                contasReceberAux = 0;

                TotalRelatorioFluxoCaixaDiario totalRelatorioFluxoCaixaDiario = new TotalRelatorioFluxoCaixaDiario();

                foreach(var total in relatorioFluxoCaixaDiario)
                {
                    despesaAux = despesa;
                    receitaAux = receita;
                    contasPagarAux = contasPagar;
                    contasReceberAux = contasReceber;

                    despesa = (despesaAux + total.receita);
                    receita = (receitaAux + total.despesa);
                    contasPagar = (contasPagarAux + total.contasReceber);
                    contasReceber = (contasReceber + total.contasPagar);

                }

                totalRelatorioFluxoCaixaDiario.receita = receita;
                totalRelatorioFluxoCaixaDiario.despesa = despesa;
                totalRelatorioFluxoCaixaDiario.contasReceber = contasReceber;
                totalRelatorioFluxoCaixaDiario.contasPagar = contasPagar;
                totalRelatorioFluxoCaixaDiario.saldoTotal = (totalRelatorioFluxoCaixaDiario.receita - totalRelatorioFluxoCaixaDiario.despesa);

                relatorioResponse.relatorio = relatorioFluxoCaixaDiario;
                relatorioResponse.totalRelatorioFluxoCaixaDiario = totalRelatorioFluxoCaixaDiario;
                relatorioResponse.Executado = true;
                relatorioResponse.MensagemRetorno = "Relatório de contas a pagar gerado com sucesso";
            }
            catch
            {
                relatorioResponse.Executado = false;
                relatorioResponse.MensagemRetorno = "Erro ao gerar o relatório de contas a pagar";
            }

            return new Response<RelatorioFluxoCaixaDiarioResponse>(relatorioResponse, $"Atualização do cadastro Contas a Pagar.");
        }

        private int getQuantidadeDiasMes(DateTime dataConsulta)
        {
            return DateTime.DaysInMonth(dataConsulta.Year, dataConsulta.Month); ;
        }

        private DateTime getDataMes(DateTime dataConsulta, int diaMes)
        {
            DateTime primeiroDiaDoMes = new DateTime(dataConsulta.Year, dataConsulta.Month, diaMes);

            return DateTime.Parse(primeiroDiaDoMes.ToString("yyyy-MM-dd"));
        }

    }
}
