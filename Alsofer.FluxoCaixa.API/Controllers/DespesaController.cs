using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Alsofer.FluxoCaixa.Application.Services.Interfaces;
using Alsofer.FluxoCaixa.Domain.Model;


namespace Alsofer.FluxoCaixa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespesaController : ControllerBase
    {
        private readonly IDespesaServices _despesaServices;
        public DespesaController(IDespesaServices despesaServices)
        {
            _despesaServices = despesaServices;
        }

        [HttpGet]
        [Route("ListarDespesa")]
        [Authorize]
        public async Task<IActionResult> ListarDespesa()
        {

            var response = await _despesaServices.ListarDespesa();

            return Ok(response);

        }

        [HttpGet]
        [Route("ListarDespesaAtivo")]
        [Authorize]
        public async Task<IActionResult> ListarDespesaAtivo()
        {

            var response = await _despesaServices.ListarDespesaAtivo();

            return Ok(response);

        }

        [HttpGet]
        [Route("ListarDadosDespesa")]
        [Authorize]
        public async Task<IActionResult> ListarDadosDespesa(int id)
        {

            var response = await _despesaServices.ListarDadosDespesa(id);

            return Ok(response);

        }

        [HttpPost]
        [Route("AdicionarDespesa")]
        [Authorize]
        public async Task<IActionResult> AdicionarDespesa(DespesaRequest despesaRequest )
        {

            var response = await _despesaServices.AdicionarDespesa(despesaRequest);

            return Ok(response);

        }

        [HttpPost]
        [Route("AtualizarDadosDespesa")]
        [Authorize]
        public async Task<IActionResult> AtualizarDadosDespesa(DespesaRequest despesaRequest)
        {

            var response = await _despesaServices.AtualizarDadosDespesa(despesaRequest);

            return Ok(response);

        }

    }
}
