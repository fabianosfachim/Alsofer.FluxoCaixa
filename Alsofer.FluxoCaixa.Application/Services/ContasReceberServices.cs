

using Alsofer.FluxoCaixa.Application.Services.Interfaces;
using Alsofer.FluxoCaixa.Application.Services.Wrappers;
using Alsofer.FluxoCaixa.Data.Interfaces;
using Alsofer.FluxoCaixa.Data.Repositories.Entities;
using Alsofer.FluxoCaixa.Domain.Model;

namespace Alsofer.FluxoCaixa.Application.Services
{
    public class ContasReceberServices : IContasReceberServices
    {
        private readonly IContasReceberRepository _contasReceberRepository;

        public ContasReceberServices(IContasReceberRepository contasReceberRepository)
        {
            _contasReceberRepository = contasReceberRepository;
        }

        public async Task<Response<ContasReceberResponse>> AdicionarContasReceber(ContasReceberRequest contasReceberRequest)
        {
            ContasReceberResponse contasReceberResponse = new ContasReceberResponse();

            try
            {
                await _contasReceberRepository.AddAsync(contasReceberRequest.contasReceber);

                //Id para chamar o cadastro da despesa
                var idContaPagar = contasReceberRequest.contasReceber.id;

                if (idContaPagar > 0)
                {
                    contasReceberResponse.objContasReceber = contasReceberRequest.contasReceber;
                    contasReceberResponse.Executado = true;
                    contasReceberResponse.MensagemRetorno = "Cadastro de contas a receber efetuado com sucesso";
                }
                else
                {
                    contasReceberResponse.Executado = true;
                    contasReceberResponse.MensagemRetorno = "Erro ao cadastrar a conta a receber, tente novamente";
                }
            }
            catch
            {
                contasReceberResponse.Executado = false;
                contasReceberResponse.MensagemRetorno = "Erro ao cadastrar a conta a receber";
            }

            return new Response<ContasReceberResponse>(contasReceberResponse, $"Cadastro Contas a Receber.");
        }

        public async Task<Response<ContasReceberResponse>> AtualizarDadosContasReceber(ContasReceberRequest contasReceberRequest)
        {
            ContasReceberResponse contasReceberResponse = new ContasReceberResponse();

            try
            {
                await _contasReceberRepository.UpdateAsync(contasReceberRequest.contasReceber);

                contasReceberResponse.objContasReceber = contasReceberRequest.contasReceber;
                contasReceberResponse.Executado = true;
                contasReceberResponse.MensagemRetorno = "Atualização do cadastro de contas a receber efetuado com sucesso";

            }
            catch
            {
                contasReceberResponse.Executado = false;
                contasReceberResponse.MensagemRetorno = "Erro ao atualizar o cadastro da conta a receber";
            }

            return new Response<ContasReceberResponse>(contasReceberResponse, $"Atualização do Cadastro Contas a Receber.");
        }

        public async Task<Response<ContasReceberResponse>> ExcluirDadosContasReceber(int id)
        {
            ContasReceberResponse contasReceberResponse = new ContasReceberResponse();

            try
            {
                await _contasReceberRepository.RemoveAsync(id);

                contasReceberResponse.Executado = true;
                contasReceberResponse.MensagemRetorno = "Exclusão do cadastro de contas a receber efetuado com sucesso";

            }
            catch
            {
                contasReceberResponse.Executado = false;
                contasReceberResponse.MensagemRetorno = "Erro ao excluir o cadastro da conta a receber";
            }

            return new Response<ContasReceberResponse>(contasReceberResponse, $"Exclusão do Cadastro Contas a Receber.");
        }

        public async Task<Response<ContasReceberResponse>> ListarContasReceber()
        {
            ContasReceberResponse contasReceberResponse = new ContasReceberResponse();

            try
            {
               var contasReceber = await _contasReceberRepository.GetAllAsync();

                if(contasReceber.Any())
                {
                    contasReceberResponse.ContasReceber = contasReceber.ToList();
                    contasReceberResponse.Executado = true;
                    contasReceberResponse.MensagemRetorno = "Consulta do cadastro de contas a receber efetuado com sucesso";
                }
                else
                {
                    contasReceberResponse.Executado = true;
                    contasReceberResponse.MensagemRetorno = "Consulta do cadastro de contas a receber efetuado com sucesso";
                }

            }
            catch
            {
                contasReceberResponse.Executado = false;
                contasReceberResponse.MensagemRetorno = "Erro ao consultar o cadastro da conta a receber";
            }

            return new Response<ContasReceberResponse>(contasReceberResponse, $"Consulta do Cadastro Contas a Receber.");
        }

        public async Task<Response<ContasReceberResponse>> ListarContasReceber(DateTime dataConsulta)
        {
            ContasReceberResponse contasReceberResponse = new ContasReceberResponse();

            try
            {
                var contasReceber = await _contasReceberRepository.GetAsync( x => x.dtPagamento >=  DateTime.Parse(dataConsulta.ToString("yyyy-MM-dd") + " 00:00:00") && x.dtPagamento <= DateTime.Parse(dataConsulta.ToString("yyyy-MM-dd") + " 23:59:59"));

                if (contasReceber.Any())
                {
                    contasReceberResponse.ContasReceber = contasReceber.ToList();
                    contasReceberResponse.Executado = true;
                    contasReceberResponse.MensagemRetorno = "Consulta do cadastro de contas a receber efetuado com sucesso";
                }
                else
                {
                    contasReceberResponse.Executado = true;
                    contasReceberResponse.MensagemRetorno = "Consulta do cadastro de contas a receber efetuado com sucesso";
                }

            }
            catch
            {
                contasReceberResponse.Executado = false;
                contasReceberResponse.MensagemRetorno = "Erro ao consultar o cadastro da conta a receber";
            }

            return new Response<ContasReceberResponse>(contasReceberResponse, $"Consulta do Cadastro Contas a Receber.");
        }

        public async Task<Response<ContasReceberResponse>> ListarDadosContasReceber(int id)
        {
            ContasReceberResponse contasReceberResponse = new ContasReceberResponse();

            try
            {
                var contasReceber = await _contasReceberRepository.GetByIdAsync(id);

                if (contasReceber != null)
                {
                    contasReceberResponse.objContasReceber = contasReceber;
                    contasReceberResponse.Executado = true;
                    contasReceberResponse.MensagemRetorno = "Consulta do cadastro de contas a receber efetuado com sucesso";
                }
                else
                {
                    contasReceberResponse.Executado = true;
                    contasReceberResponse.MensagemRetorno = "Não existem dados para esta consulta";
                }

            }
            catch
            {
                contasReceberResponse.Executado = false;
                contasReceberResponse.MensagemRetorno = "Erro ao consultar o cadastro da conta a receber";
            }

            return new Response<ContasReceberResponse>(contasReceberResponse, $"Consulta do Cadastro Contas a Receber.");
        }
    }
}
