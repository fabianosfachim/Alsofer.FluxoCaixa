using Alsofer.FluxoCaixa.Application.Services.Interfaces;
using Alsofer.FluxoCaixa.Application.Services.Wrappers;
using Alsofer.FluxoCaixa.Data.Interfaces;
using Alsofer.FluxoCaixa.Domain.Model;

namespace Alsofer.FluxoCaixa.Application.Services
{
    public class DespesaServices : IDespesaServices
    {
        private readonly IDespesaRepository _despesaRepository;

        public DespesaServices(IDespesaRepository despesaRepository)
        {
            _despesaRepository = despesaRepository;
        }

        public async Task<Response<DespesaResponse>> AdicionarDespesa(DespesaRequest despesaRequest)
        {
            DespesaResponse despesaResponse = new DespesaResponse();

            try
            {
                await _despesaRepository.AddAsync(despesaRequest.despesa);

                //Id para chamar o cadastro da despesa
                var idDespesa = despesaRequest.despesa.id;

                if(idDespesa > 0)
                {
                    despesaResponse.objDespesa = despesaRequest.despesa;
                    despesaResponse.Executado = true;
                    despesaResponse.MensagemRetorno = "Cadastro de despesa efetuado com sucesso";
                }
                else
                {
                    despesaResponse.Executado = true;
                    despesaResponse.MensagemRetorno = "Erro ao cadastrar a despesa, tente novamente";
                }
            }
            catch
            {
                despesaResponse.Executado = false;
                despesaResponse.MensagemRetorno = "Erro ao cadastrar a despesa";
            }

            return new Response<DespesaResponse>(despesaResponse, $"Cadastro Despesa.");
        }

        public async Task<Response<DespesaResponse>> AtualizarDadosDespesa(DespesaRequest despesaRequest)
        {

            DespesaResponse despesaResponse = new DespesaResponse();

            try
            {
                await _despesaRepository.UpdateAsync(despesaRequest.despesa);

                despesaResponse.objDespesa = despesaRequest.despesa;
                despesaResponse.Executado = true;
                despesaResponse.MensagemRetorno = "Atualização do cadastro de despesa efetuado com sucesso";
            }
            catch
            {
                despesaResponse.Executado = false;
                despesaResponse.MensagemRetorno = "Erro ao atualizar o cadastrar a despesa";
            }

            return new Response<DespesaResponse>(despesaResponse, $"Atualização do Cadastro Despesa.");

        }

        public async Task<Response<DespesaResponse>> ListarDadosDespesa(int id)
        {
            DespesaResponse despesaResponse = new DespesaResponse();

            try
            {
               var despesa = await _despesaRepository.GetByIdAsync(id);
               
                if(despesa != null)
                {
                    despesaResponse.objDespesa = despesa;
                    despesaResponse.Executado = true;
                    despesaResponse.MensagemRetorno = "Consulta do cadastro de despesa efetuado com sucesso";
                }
                else
                {
                    despesaResponse.Executado = true;
                    despesaResponse.MensagemRetorno = "Consulta do cadastro de despesa efetuado com sucesso";
                }
            }
            catch
            {
                despesaResponse.Executado = false;
                despesaResponse.MensagemRetorno = "Erro ao atualizar o cadastrar a despesa";
            }

            return new Response<DespesaResponse>(despesaResponse, $"Atualização do Cadastro Despesa.");
        }

        public async Task<Response<DespesaResponse>> ListarDespesa()
        {
            DespesaResponse despesaResponse = new DespesaResponse();

            try
            {
                var despesa = await _despesaRepository.GetAllAsync();

                if (despesa.Any())
                {
                    despesaResponse.Despesa = despesa.ToList();
                    despesaResponse.Executado = true;
                    despesaResponse.MensagemRetorno = "Consulta do cadastro de despesa efetuado com sucesso";
                }
                else
                {
                    despesaResponse.Executado = true;
                    despesaResponse.MensagemRetorno = "Não existe dados cadastrados no banco de dados";
                }
            }
            catch
            {
                despesaResponse.Executado = false;
                despesaResponse.MensagemRetorno = "Erro ao realizar a consulta no cadastro de despesa";
            }

            return new Response<DespesaResponse>(despesaResponse, $"Consulta do Cadastro Despesa.");
        }

        public async Task<Response<DespesaResponse>> ListarDespesaAtivo()
        {
            DespesaResponse despesaResponse = new DespesaResponse();

            try
            {
                var despesa = await _despesaRepository.GetAsync(x => x.ativo == true);

                if (despesa.Any())
                {
                    despesaResponse.Despesa = despesa.ToList();
                    despesaResponse.Executado = true;
                    despesaResponse.MensagemRetorno = "Consulta do cadastro de despesa efetuado com sucesso";
                }
                else
                {
                    despesaResponse.Executado = true;
                    despesaResponse.MensagemRetorno = "Não existe dados cadastrados no banco de dados";
                }
            }
            catch
            {
                despesaResponse.Executado = false;
                despesaResponse.MensagemRetorno = "Erro ao realizar a consulta no cadastro de despesa";
            }

            return new Response<DespesaResponse>(despesaResponse, $"Consulta do Cadastro Despesa.");
        }
    }
}
