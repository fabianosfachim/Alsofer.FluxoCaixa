﻿using Alsofer.FluxoCaixa.Domain.Entities;

namespace Alsofer.FluxoCaixa.Domain.Model
{
    public class LoginResponse
    {
        public LoginModel loginModel { get; set; }
        public bool Executado { get; set; }
        public string MensagemRetorno { get; set; }
    }
}
