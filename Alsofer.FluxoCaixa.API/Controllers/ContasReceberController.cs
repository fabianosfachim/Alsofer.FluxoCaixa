using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Alsofer.FluxoCaixa.Application.Services.Interfaces;
using Alsofer.FluxoCaixa.Domain.Model;


namespace Alsofer.FluxoCaixa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasReceberController : ControllerBase
    {
        private readonly IContasReceberServices _contasReceberServices;
        public ContasReceberController(IContasReceberServices contasReceberServices)
        {
            _contasReceberServices = contasReceberServices;
        }

        [HttpGet]
        [Route("ListarContasReceber")]
        [Authorize]
        public async Task<IActionResult> ListarContasReceber()
        {

            var response = await _contasReceberServices.ListarContasReceber();

            return Ok(response);

        }

        [HttpGet]
        [Route("ListarDadosContasReceber")]
        [Authorize]
        public async Task<IActionResult> ListarDadosContasReceber(int id)
        {

            var response = await _contasReceberServices.ListarDadosContasReceber(id);

            return Ok(response);

        }

        [HttpPost]
        [Route("AdicionarContasReceber")]
        [Authorize]
        public async Task<IActionResult> AdicionarContasReceber(ContasReceberRequest contasReceberRequest)
        {

            var response = await _contasReceberServices.AdicionarContasReceber(contasReceberRequest);

            return Ok(response);

        }

        [HttpPost]
        [Route("AtualizarDadosContasReceber")]
        [Authorize]
        public async Task<IActionResult> AtualizarDadosContasReceber(ContasReceberRequest contasReceberRequest)
        {

            var response = await _contasReceberServices.AtualizarDadosContasReceber(contasReceberRequest);

            return Ok(response);

        }

        [HttpPost]
        [Route("ExcluirDadosContasReceber")]
        [Authorize]
        public async Task<IActionResult> ExcluirDadosContasReceber(int id)
        {

            var response = await _contasReceberServices.ExcluirDadosContasReceber(id);

            return Ok(response);

        }
    }
}
