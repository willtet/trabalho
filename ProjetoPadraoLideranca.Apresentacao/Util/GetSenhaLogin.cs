using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lidercap.Auth;
using Lidercap.Auth.Domain.Entities;

namespace ProjetoPadraoLideranca.Apresentacao.Util
{
    public static class GetSenhaLogin
    {
        public static GetSenha GetSenha = new GetSenha();
        public static User User;

        static GetSenhaLogin()
        {
            User = GetSenha.GetUser();
        }
    }
}