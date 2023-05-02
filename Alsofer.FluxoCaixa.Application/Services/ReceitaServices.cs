using Alsofer.FluxoCaixa.Application.Services.Interfaces;
using Alsofer.FluxoCaixa.Application.Services.Wrappers;
using Alsofer.FluxoCaixa.Data.Interfaces;
using Alsofer.FluxoCaixa.Data.Repositories.Entities;
using Alsofer.FluxoCaixa.Domain.Model;

namespace Alsofer.FluxoCaixa.Application.Services
{
    public class ReceitaServices : IReceitaServices
    {
        private readonly IReceitaRepository _receitaRepository;

        public ReceitaServices(IReceitaRepository receitaRepository)
        {
            _receitaRepository = receitaRepository;
        }

        public async Task<Response<ReceitaResponse>> AdicionarReceita(ReceitaRequest receitaRequest)
        {
            ReceitaResponse receitaResponse = new ReceitaResponse();

            try
            {
                await _receitaRepository.AddAsync(receitaRequest.receita);

                //Id para chamar o cadastro da despesa
                var idReceita = receitaRequest.receita.id;

                if (idReceita > 0)
                {
                    receitaResponse.objReceita = receitaRequest.receita;
                    receitaResponse.Executado = true;
                    receitaResponse.MensagemRetorno = "Cadastro de receita efetuado com sucesso";
                }
                else
                {
                    receitaResponse.Executado = true;
                    receitaResponse.MensagemRetorno = "Erro ao cadastrar a receita, tente novamente";
                }
            }
            catch
            {
                receitaResponse.Executado = false;
                receitaResponse.MensagemRetorno = "Erro ao cadastrar a receita";
            }

            return new Response<ReceitaResponse>(receitaResponse, $"Cadastro Receita.");
        }

        public async Task<Response<ReceitaResponse>> AtualizarDadosReceita(ReceitaRequest receitaRequest)
        {
            ReceitaResponse receitaResponse = new ReceitaResponse();

            try
            {
                await _receitaRepository.UpdateAsync(receitaRequest.receita);

                receitaResponse.objReceita = receitaRequest.receita;
                receitaResponse.Executado = true;
                receitaResponse.MensagemRetorno = "Atualização do cadastro de receita efetuado com sucesso";

            }
            catch
            {
                receitaResponse.Executado = false;
                receitaResponse.MensagemRetorno = "Erro ao atualizar cadastro da receita";
            }

            return new Response<ReceitaResponse>(receitaResponse, $"Atualizar Cadastro Receita.");
        }

        public async Task<Response<ReceitaResponse>> ListarDadosReceita(int id)
        {
            ReceitaResponse receitaResponse = new ReceitaResponse();

            try
            {
               var receita = await _receitaRepository.GetByIdAsync(id);
               
                if(receita != null)
                {
                    receitaResponse.objReceita = receita;
                    receitaResponse.Executado = true;
                    receitaResponse.MensagemRetorno = "Consulta do cadastro de receita efetuado com sucesso";
                }
                else
                {
                    receitaResponse.Executado = true;
                    receitaResponse.MensagemRetorno = "Não existem dados para esta consulta";
                }
                
            }
            catch
            {
                receitaResponse.Executado = false;
                receitaResponse.MensagemRetorno = "Erro ao consultar cadastro da receita";
            }

            return new Response<ReceitaResponse>(receitaResponse, $"Consultar Cadastro Receita.");
        }

        public async Task<Response<ReceitaResponse>> ListarReceita()
        {
            ReceitaResponse receitaResponse = new ReceitaResponse();

            try
            {
                var receita = await _receitaRepository.GetAllAsync();

                if (receita.Any())
                {
                    receitaResponse.Receita = receita.ToList();
                    receitaResponse.Executado = true;
                    receitaResponse.MensagemRetorno = "Consulta do cadastro de receita efetuado com sucesso";
                }
                else
                {
                    receitaResponse.Executado = true;
                    receitaResponse.MensagemRetorno = "Não existem dados para esta consulta";
                }

            }
            catch
            {
                receitaResponse.Executado = false;
                receitaResponse.MensagemRetorno = "Erro ao consultar cadastro da receita";
            }

            return new Response<ReceitaResponse>(receitaResponse, $"Consultar Cadastro Receita.");
        }

        public async Task<Response<ReceitaResponse>> ListarReceitaAtivo()
        {
            ReceitaResponse receitaResponse = new ReceitaResponse();

            try
            {
                var receita = await _receitaRepository.GetAsync(x => x.ativo == true);

                if (receita.Any())
                {
                    receitaResponse.Receita = receita.ToList();
                    receitaResponse.Executado = true;
                    receitaResponse.MensagemRetorno = "Consulta do cadastro de receita efetuado com sucesso";
                }
                else
                {
                    receitaResponse.Executado = true;
                    receitaResponse.MensagemRetorno = "Não existem dados para esta consulta";
                }

            }
            catch
            {
                receitaResponse.Executado = false;
                receitaResponse.MensagemRetorno = "Erro ao consultar cadastro da receita";
            }

            return new Response<ReceitaResponse>(receitaResponse, $"Consultar Cadastro Receita.");
        }
    }
}
