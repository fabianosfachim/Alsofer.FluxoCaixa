using Alsofer.FluxoCaixa.Application.Services.Wrappers;
using Alsofer.FluxoCaixa.Domain.Model;

namespace Alsofer.FluxoCaixa.Application.Services.Interfaces
{
    public interface IReceitaServices
    {
        Task<Response<ReceitaResponse>> ListarReceita();
        Task<Response<ReceitaResponse>> ListarDadosReceita(int id);
        Task<Response<ReceitaResponse>> ListarReceitaAtivo();
        Task<Response<ReceitaResponse>> AdicionarReceita(ReceitaRequest receitaRequest);
        Task<Response<ReceitaResponse>> AtualizarDadosReceita(ReceitaRequest receitaRequest);
    }
}
