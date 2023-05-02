using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Alsofer.FluxoCaixa.Application.Services.Interfaces;
using Alsofer.FluxoCaixa.Domain.Model;
using Alsofer.FluxoCaixa.Application.Services;

namespace Alsofer.FluxoCaixa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasPagarController : ControllerBase
    {
        private readonly IContasPagarServices _contasPagarServices;
        public ContasPagarController(IContasPagarServices contasPagarServices)
        {
            _contasPagarServices = contasPagarServices;
        }

        [HttpGet]
        [Route("ListarContasPagar")]
        [Authorize]
        public async Task<IActionResult> ListarContasPagar()
        {
            var response = await _contasPagarServices.ListarContasPagar();
            return Ok(response);

        }

        [HttpGet]
        [Route("ListarDadosContasPagar")]
        [Authorize]
        public async Task<IActionResult> ListarDadosContasPagar(int id)
        {

            var response = await _contasPagarServices.ListarDadosContasPagar(id);

            return Ok(response);

        }

        [HttpPost]
        [Route("AdicionarContasPagar")]
        [Authorize]
        public async Task<IActionResult> AdicionarContasPagar(ContasPagarRequest contasPagarRequest)
        {

            var response = await _contasPagarServices.AdicionarContasPagar(contasPagarRequest);

            return Ok(response);

        }

        [HttpPost]
        [Route("AtualizarDadosContasPagar")]
        [Authorize]
        public async Task<IActionResult> AtualizarDadosContasPagar(ContasPagarRequest contasPagarRequest)
        {

            var response = await _contasPagarServices.AtualizarDadosContasPagar(contasPagarRequest);

            return Ok(response);

        }

        [HttpPost]
        [Route("EscluirDadosContasPagar")]
        [Authorize]
        public async Task<IActionResult> EscluirDadosContasPagar(int id)
        {

            var response = await _contasPagarServices.EscluirDadosContasPagar(id);

            return Ok(response);

        }
    }
}
