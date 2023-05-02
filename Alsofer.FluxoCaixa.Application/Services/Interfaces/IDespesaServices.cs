using Alsofer.FluxoCaixa.Application.Services.Wrappers;
using Alsofer.FluxoCaixa.Domain.Model;


namespace Alsofer.FluxoCaixa.Application.Services.Interfaces
{
    public interface IDespesaServices
    {
        Task<Response<DespesaResponse>> ListarDespesa();
        Task<Response<DespesaResponse>> ListarDadosDespesa(int id);
        Task<Response<DespesaResponse>> ListarDespesaAtivo();
        Task<Response<DespesaResponse>> AdicionarDespesa(DespesaRequest despesaRequest);
        Task<Response<DespesaResponse>> AtualizarDadosDespesa(DespesaRequest despesaRequest);
    }
}
