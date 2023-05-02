using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Alsofer.FluxoCaixa.Application.Services.Interfaces;
using Alsofer.FluxoCaixa.Domain.Model;

namespace Alsofer.FluxoCaixa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServices _clienteServices;
        public ClienteController(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        [HttpGet]
        [Route("ListarClientes")]
        [Authorize]
        public async Task<IActionResult> ListarClientes()
        {

            var response = await _clienteServices.ListarClientes();

            return Ok(response);

        }

        [HttpGet]
        [Route("ListarDadosCliente")]
        [Authorize]
        public async Task<IActionResult> ListarDadosCliente(int id)
        {

            var response = await _clienteServices.ListarDadosCliente(id);

            return Ok(response);

        }

        [HttpGet]
        [Route("ListarClientesAtivos")]
        [Authorize]
        public async Task<IActionResult> ListarClientesAtivos()
        {

            var response = await _clienteServices.ListarClientesAtivos();

            return Ok(response);

        }

        [HttpPost]
        [Route("AdicionarClientes")]
        [Authorize]
        public async Task<IActionResult> AdicionarClientes(ClienteRequest clienteRequest)
        {

            var response = await _clienteServices.AdicionarClientes(clienteRequest);

            return Ok(response);

        }

        [HttpPost]
        [Route("AtualizarDadosCliente")]
        [Authorize]
        public async Task<IActionResult> AtualizarDadosCliente(ClienteRequest clienteRequest)
        {

            var response = await _clienteServices.AtualizarDadosCliente(clienteRequest);

            return Ok(response);

        }

    }
}
