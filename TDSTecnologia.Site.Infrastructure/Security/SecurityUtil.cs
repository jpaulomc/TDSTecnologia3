using Microsoft.AspNetCore.Identity;
using System;
using TDSTecnologia.Site.Core.Entities;

namespace TDSTecnologia.Site.Infrastructure.Security
{
    public class SecurityUtil
    {
        public static bool CompararSenhas(Usuario usuario, string senha)
        {
            if (String.IsNullOrEmpty(senha))
            {
                return false;
            }

            if (usuario == null || String.IsNullOrEmpty(usuario.PasswordHash))
            {
                return false;
            }

            PasswordHasher<Usuario> passwordHasher = new PasswordHasher<Usuario>();
            return (passwordHasher.VerifyHashedPassword(usuario, usuario.PasswordHash, senha) != PasswordVerificationResult.Failed);
        }

    }
}
