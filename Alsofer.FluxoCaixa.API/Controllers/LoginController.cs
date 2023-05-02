using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Alsofer.FluxoCaixa.Application.Services.Interfaces;
using Alsofer.FluxoCaixa.Domain.Model;
using Alsofer.FluxoCaixa.Application.Services;

namespace Alsofer.FluxoCaixa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServices _loginServices;
        public LoginController(ILoginServices loginServices)
        {
            _loginServices = loginServices;
        }

        [HttpPost]
        [Route("LoginSistema")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] AuthUser model)
        {
            if (model == null)
                return NotFound(new { message = "O Parâmetro model não pode ser vazio" });

            var _login = await _loginServices.LoginSistema(model.email, model.password);
            if (!_login.Data.Executado)
                return NotFound(new { message = "Credenciais inválida, contate o administrador da aplicação" });

            // Gera o Token
            var token = TokenService.GenerateToken(model);
            // Retorna os dados
            return new
            {
                token = token, 
                data = _login
            };
        }

    }
}