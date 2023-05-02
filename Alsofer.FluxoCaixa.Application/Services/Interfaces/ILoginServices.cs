using Alsofer.FluxoCaixa.Application.Services.Wrappers;
using Alsofer.FluxoCaixa.Domain.Entities;
using Alsofer.FluxoCaixa.Domain.Model;

namespace Alsofer.FluxoCaixa.Application.Services.Interfaces
{
    public interface ILoginServices
    {
        Task<Response<LoginResponse>> LoginSistema(string email, string password);

    }
}
