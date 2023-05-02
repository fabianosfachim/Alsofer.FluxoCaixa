using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Alsofer.FluxoCaixa.Application.Services.Interfaces;
using Alsofer.FluxoCaixa.Domain.Model;
using Alsofer.FluxoCaixa.Application.Services;

namespace Alsofer.FluxoCaixa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorServices _fornecedorServices;
      
        public FornecedorController(IFornecedorServices fornecedorServices)
        {
            _fornecedorServices = fornecedorServices;
        }

        [HttpGet]
        [Route("ListarFornecedor")]
        [Authorize]
        public async Task<IActionResult> ListarFornecedor()
        {

            var response = await _fornecedorServices.ListarFornecedor();

            return Ok(response);

        }

        [HttpGet]
        [Route("ListarDadosFornecedor")]
        [Authorize]
        public async Task<IActionResult> ListarDadosFornecedor(int id)
        {

            var response = await _fornecedorServices.ListarDadosFornecedor(id);

            return Ok(response);

        }

        [HttpGet]
        [Route("ListarFornecedorAtivo")]
        [Authorize]
        public async Task<IActionResult> ListarFornecedorAtivo()
        {

            var response = await _fornecedorServices.ListarFornecedorAtivo();

            return Ok(response);

        }

        [HttpPost]
        [Route("AdicionarFornecedor")]
        [Authorize]
        public async Task<IActionResult> AdicionarClientes(FornecedorRequest fornecedorRequest)
        {

            var response = await _fornecedorServices.AdicionarFornecedor(fornecedorRequest);

            return Ok(response);

        }

        [HttpPost]
        [Route("AtualizarDadosFornecedor")]
        [Authorize]
        public async Task<IActionResult> AtualizarDadosCliente(FornecedorRequest fornecedorRequest)
        {

            var response = await _fornecedorServices.AtualizarDadosFornecedor(fornecedorRequest);

            return Ok(response);

        }
    }
}
