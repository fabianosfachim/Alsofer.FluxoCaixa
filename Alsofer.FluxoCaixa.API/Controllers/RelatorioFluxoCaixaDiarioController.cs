using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Alsofer.FluxoCaixa.Application.Services.Interfaces;
using Alsofer.FluxoCaixa.Application.Services;
using Alsofer.FluxoCaixa.Domain.Model;

namespace Alsofer.FluxoCaixa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioFluxoCaixaDiarioController : ControllerBase
    {
        private readonly IRelatorioFluxoCaixaDiarioServices _relatorioFluxoCaixaDiarioServices;

        public RelatorioFluxoCaixaDiarioController(IRelatorioFluxoCaixaDiarioServices relatorioFluxoCaixaDiarioServices)
        {
            _relatorioFluxoCaixaDiarioServices = relatorioFluxoCaixaDiarioServices;
        }

        [HttpPost]
        [Route("ListarRelatorioFluxoCaixaDiario")]
        public async Task<IActionResult> ListarRelatorioFluxoCaixaDiario(RelatorioFluxoCaixaDiarioRequest relatorioFluxoCaixaDiarioRequest)
        {

            var response = await _relatorioFluxoCaixaDiarioServices.GetRelatorioDiarioFluxoCaixa(relatorioFluxoCaixaDiarioRequest);
            HttpContext.Response.ContentType = "application/json";

            return Ok(response);
        }
    }
}
