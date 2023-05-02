
using Alsofer.FluxoCaixa.Application.Services.Wrappers;
using Alsofer.FluxoCaixa.Domain.Model;

namespace Alsofer.FluxoCaixa.Application.Services.Interfaces
{
    public interface IContasPagarServices
    {
        Task<Response<ContasPagarResponse>> ListarContasPagar(DateTime dtConsulta);
        Task<Response<ContasPagarResponse>> ListarContasPagar();
        Task<Response<ContasPagarResponse>> ListarDadosContasPagar(int id);
        Task<Response<ContasPagarResponse>> AdicionarContasPagar(ContasPagarRequest contasPagarRequest);
        Task<Response<ContasPagarResponse>> AtualizarDadosContasPagar(ContasPagarRequest contasPagarRequest);
        Task<Response<ContasPagarResponse>> EscluirDadosContasPagar(int id);
    }
}
