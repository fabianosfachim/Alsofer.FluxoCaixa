using Alsofer.FluxoCaixa.Application.Services.Wrappers;
using Alsofer.FluxoCaixa.Domain.Entities;
using Alsofer.FluxoCaixa.Domain.Model;

namespace Alsofer.FluxoCaixa.Application.Services.Interfaces
{
    public interface IStatusServices
    {
        Task<Response<StatusResponse>> ListarStatus();
        Task<Response<StatusResponse>> ListarStatusAtivo();
    }
}
