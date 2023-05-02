using Alsofer.FluxoCaixa.Application.Services.Wrappers;
using Alsofer.FluxoCaixa.Domain.Entities;
using Alsofer.FluxoCaixa.Domain.Model;

namespace Alsofer.FluxoCaixa.Application.Services.Interfaces
{
    public interface IFornecedorServices
    {
        Task<Response<FornecedorResponse>> ListarFornecedor();
        Task<Response<FornecedorResponse>> ListarDadosFornecedor(int id);
        Task<Response<FornecedorResponse>> ListarFornecedorAtivo();
        Task<Response<FornecedorResponse>> AdicionarFornecedor(FornecedorRequest fornecedorRequest);
        Task<Response<FornecedorResponse>> AtualizarDadosFornecedor(FornecedorRequest fornecedorRequest);
    }
}
