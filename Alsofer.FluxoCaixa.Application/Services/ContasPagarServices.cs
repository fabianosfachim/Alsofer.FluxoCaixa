using Alsofer.FluxoCaixa.Application.Services.Interfaces;
using Alsofer.FluxoCaixa.Application.Services.Wrappers;
using Alsofer.FluxoCaixa.Data.Interfaces;
using Alsofer.FluxoCaixa.Data.Repositories.Entities;
using Alsofer.FluxoCaixa.Domain.Model;

namespace Alsofer.FluxoCaixa.Application.Services
{
    public class ContasPagarServices : IContasPagarServices
    {
        private readonly IContasPagarRepository _contasPagarRepository;

        public ContasPagarServices(IContasPagarRepository contasPagarRepository)
        {
            _contasPagarRepository = contasPagarRepository;
        }

        public async Task<Response<ContasPagarResponse>> AdicionarContasPagar(ContasPagarRequest contasPagarRequest)
        {
            ContasPagarResponse contasPagarResponse = new ContasPagarResponse();

            try
            {
                await _contasPagarRepository.AddAsync(contasPagarRequest.contasPagar);

                //Id para chamar o cadastro da despesa
                var idContaPagar = contasPagarRequest.contasPagar.id;

                if (idContaPagar > 0)
                {
                    contasPagarResponse.objContasPagar = contasPagarRequest.contasPagar;
                    contasPagarResponse.Executado = true;
                    contasPagarResponse.MensagemRetorno = "Cadastro de contas a pagar efetuado com sucesso";
                }
                else
                {
                    contasPagarResponse.Executado = true;
                    contasPagarResponse.MensagemRetorno = "Erro ao cadastrar a conta a pagar, tente novamente";
                }
            }
            catch
            {
                contasPagarResponse.Executado = false;
                contasPagarResponse.MensagemRetorno = "Erro ao cadastrar a conta a pagar";
            }

            return new Response<ContasPagarResponse>(contasPagarResponse, $"Cadastro Contas a Pagar.");
        }

        public async Task<Response<ContasPagarResponse>> AtualizarDadosContasPagar(ContasPagarRequest contasPagarRequest)
        {
            ContasPagarResponse contasPagarResponse = new ContasPagarResponse();

            try
            {
                await _contasPagarRepository.UpdateAsync(contasPagarRequest.contasPagar);

                contasPagarResponse.objContasPagar = contasPagarRequest.contasPagar;
                contasPagarResponse.Executado = true;
                contasPagarResponse.MensagemRetorno = "Atualização do cadastro de contas a pagar efetuado com sucesso";
            }
            catch
            {
                contasPagarResponse.Executado = false;
                contasPagarResponse.MensagemRetorno = "Erro ao cadastrar a conta a pagar";
            }

            return new Response<ContasPagarResponse>(contasPagarResponse, $"Atualização do cadastro Contas a Pagar.");
        }

        public async Task<Response<ContasPagarResponse>> EscluirDadosContasPagar(int id)
        {
            ContasPagarResponse contasPagarResponse = new ContasPagarResponse();

            try
            {
                await _contasPagarRepository.RemoveAsync(id);

                contasPagarResponse.Executado = true;
                contasPagarResponse.MensagemRetorno = "Exclusão do cadastro de contas a pagar efetuado com sucesso";
            }
            catch
            {
                contasPagarResponse.Executado = false;
                contasPagarResponse.MensagemRetorno = "Erro ao excluir a conta a pagar";
            }

            return new Response<ContasPagarResponse>(contasPagarResponse, $"Atualização do cadastro Contas a Pagar.");
        }

        public async Task<Response<ContasPagarResponse>> ListarContasPagar(DateTime dtConsulta)
        {
            ContasPagarResponse contasPagarResponse = new ContasPagarResponse();

            try
            {
               var contasPagar = await _contasPagarRepository.GetAsync(x => x.dtPagamento >= DateTime.Parse(dtConsulta.ToString("yyyy-MM-dd") + " 00:00:00") && x.dtPagamento <= DateTime.Parse(dtConsulta.ToString("yyyy-MM-dd") + " 23:59:59"));

                if(contasPagar.Any())
                {
                    contasPagarResponse.ContasPagar = contasPagar.ToList();
                    contasPagarResponse.Executado = true;
                    contasPagarResponse.MensagemRetorno = "Consulta do cadastro de contas a pagar efetuado com sucesso";
                }
                else
                {
                    contasPagarResponse.Executado = true;
                    contasPagarResponse.MensagemRetorno = "Não existem registros para esta consulta";
                }
            }
            catch
            {
                contasPagarResponse.Executado = false;
                contasPagarResponse.MensagemRetorno = "Erro ao consultas a conta a pagar";
            }

            return new Response<ContasPagarResponse>(contasPagarResponse, $"Consulta Contas a Pagar.");
        }

        public async Task<Response<ContasPagarResponse>> ListarContasPagar()
        {
            ContasPagarResponse contasPagarResponse = new ContasPagarResponse();

            try
            {
                var contasPagar = await _contasPagarRepository.GetAllAsync();

                if (contasPagar.Any())
                {
                    contasPagarResponse.ContasPagar = contasPagar.ToList();
                    contasPagarResponse.Executado = true;
                    contasPagarResponse.MensagemRetorno = "Consulta do cadastro de contas a pagar efetuado com sucesso";
                }
                else
                {
                    contasPagarResponse.Executado = true;
                    contasPagarResponse.MensagemRetorno = "Não existem registros para esta consulta";
                }
            }
            catch
            {
                contasPagarResponse.Executado = false;
                contasPagarResponse.MensagemRetorno = "Erro ao consultas a conta a pagar";
            }

            return new Response<ContasPagarResponse>(contasPagarResponse, $"Consulta Contas a Pagar.");
        }

        public async Task<Response<ContasPagarResponse>> ListarDadosContasPagar(int id)
        {
            ContasPagarResponse contasPagarResponse = new ContasPagarResponse();

            try
            {
                var contasPagar = await _contasPagarRepository.GetByIdAsync(id);

                if (contasPagar != null)
                {
                    contasPagarResponse.objContasPagar = contasPagar;
                    contasPagarResponse.Executado = true;
                    contasPagarResponse.MensagemRetorno = "Consulta do cadastro de contas a pagar efetuado com sucesso";
                }
                else
                {
                    contasPagarResponse.Executado = true;
                    contasPagarResponse.MensagemRetorno = "Não existem registros para esta consulta";
                }
            }
            catch
            {
                contasPagarResponse.Executado = false;
                contasPagarResponse.MensagemRetorno = "Erro ao consultas a conta a pagar";
            }

            return new Response<ContasPagarResponse>(contasPagarResponse, $"Consulta Contas a Pagar.");
        }
    }
}
