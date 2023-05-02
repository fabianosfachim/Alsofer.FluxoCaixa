﻿using Alsofer.FluxoCaixa.Application.Services.Interfaces;
using Alsofer.FluxoCaixa.Application.Services.Wrappers;
using Alsofer.FluxoCaixa.Data.Interfaces;
using Alsofer.FluxoCaixa.Domain.Model;

namespace Alsofer.FluxoCaixa.Application.Services
{

    public class LoginServices : ILoginServices
    {
        private readonly ILoginRepository _loginRepository;

        public LoginServices(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<Response<LoginResponse>> LoginSistema(string email, string password)
        {
            LoginResponse loginResponse = new LoginResponse();
            LoginModel _retorno = new LoginModel();
            try
            {
                var login = _loginRepository.Get(x => x.email == email && x.password == password && x.ativo == true);

                if (login.Any())
                {
                    _retorno.parser(login.FirstOrDefault());
                    loginResponse.loginModel = _retorno;
                    loginResponse.Executado = true;
                    loginResponse.MensagemRetorno = "Consulta efetuada com sucesso";
                }
                else
                {
                    loginResponse.Executado = true;
                    loginResponse.MensagemRetorno = "Dados incorretos, digite novamente";
                }

            }
            catch
            {
                loginResponse.Executado = false;
                loginResponse.MensagemRetorno = "Erro na consulta de lista de estados";
            }

            return new Response<LoginResponse>(loginResponse, $"Login Aplicação.");
        }

    }
}
