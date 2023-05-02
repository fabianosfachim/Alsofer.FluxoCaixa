using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Alsofer.FluxoCaixa.Application.Services.Interfaces;

namespace Alsofer.FluxoCaixa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusServices _statusServices;
        public StatusController(IStatusServices statusServices)
        {
            _statusServices = statusServices;
        }

        [HttpPost]
        [Route("ListarStatus")]
        [Authorize]
        public async Task<IActionResult> ListarStatus()
        {

            var response = await _statusServices.ListarStatus();
            HttpContext.Response.ContentType = "application/json";

            return Ok(response);
        }

        [HttpPost]
        [Route("ListarStatusAtivo")]
        [Authorize]
        public async Task<IActionResult> ListarStatusAtivo()
        {

            var response = await _statusServices.ListarStatusAtivo();
            HttpContext.Response.ContentType = "application/json";

            return Ok(response);
        }

    }
}
