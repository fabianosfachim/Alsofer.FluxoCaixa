using Alsofer.FluxoCaixa.Application.Services.Wrappers;
using Alsofer.FluxoCaixa.Domain.Model;

namespace Alsofer.FluxoCaixa.Application.Services.Interfaces
{
    public interface IContasReceberServices
    {
        Task<Response<ContasReceberResponse>> ListarContasReceber();
        Task<Response<ContasReceberResponse>> ListarContasReceber(DateTime dataConsulta);
        Task<Response<ContasReceberResponse>> ListarDadosContasReceber(int id);
        Task<Response<ContasReceberResponse>> AdicionarContasReceber(ContasReceberRequest contasReceberRequest);
        Task<Response<ContasReceberResponse>> AtualizarDadosContasReceber(ContasReceberRequest contasReceberRequest);
        Task<Response<ContasReceberResponse>> ExcluirDadosContasReceber(int id);
    }
}
