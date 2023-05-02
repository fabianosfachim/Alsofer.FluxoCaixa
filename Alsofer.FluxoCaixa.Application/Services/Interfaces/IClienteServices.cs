using Alsofer.FluxoCaixa.Application.Services.Wrappers;
using Alsofer.FluxoCaixa.Domain.Entities;
using Alsofer.FluxoCaixa.Domain.Model;

namespace Alsofer.FluxoCaixa.Application.Services.Interfaces
{
    public interface IClienteServices
    {
        Task<Response<ClienteResponse>> ListarClientes();
        Task<Response<ClienteResponse>> ListarDadosCliente(int id);
        Task<Response<ClienteResponse>> ListarClientesAtivos();
        Task<Response<ClienteResponse>> AdicionarClientes(ClienteRequest clienteRequest);
        Task<Response<ClienteResponse>> AtualizarDadosCliente(ClienteRequest clienteRequest);

    }
}
