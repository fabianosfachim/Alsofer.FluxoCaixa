using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Alsofer.FluxoCaixa.Application.Services.Interfaces;
using Alsofer.FluxoCaixa.Domain.Model;
using Alsofer.FluxoCaixa.Application.Services;

namespace Alsofer.FluxoCaixa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private readonly IReceitaServices _receitaServices;

        public ReceitaController(IReceitaServices receitaServices)
        {
            _receitaServices = receitaServices;
        }

        [HttpGet]
        [Route("ListarReceita")]
        [Authorize]
        public async Task<IActionResult> ListarReceita()
        {

            var response = await _receitaServices.ListarReceita();

            return Ok(response);

        }

        [HttpGet]
        [Route("ListarReceitaAtivo")]
        [Authorize]
        public async Task<IActionResult> ListarReceitaAtivo()
        {

            var response = await _receitaServices.ListarReceitaAtivo();

            return Ok(response);

        }

        [HttpGet]
        [Route("ListarDadosReceita")]
        [Authorize]
        public async Task<IActionResult> ListarDadosDespesa(int id)
        {

            var response = await _receitaServices.ListarDadosReceita(id);

            return Ok(response);

        }

        [HttpPost]
        [Route("AdicionarReceita")]
        [Authorize]
        public async Task<IActionResult> AdicionarDespesa(ReceitaRequest receitaRequest)
        {

            var response = await _receitaServices.AdicionarReceita(receitaRequest);

            return Ok(response);

        }

        [HttpPost]
        [Route("AtualizarDadosReceita")]
        [Authorize]
        public async Task<IActionResult> AtualizarDadosDespesa(ReceitaRequest receitaRequest)
        {

            var response = await _receitaServices.AtualizarDadosReceita(receitaRequest);

            return Ok(response);

        }
    }
}
