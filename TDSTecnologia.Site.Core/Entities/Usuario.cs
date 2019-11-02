using Microsoft.AspNetCore.Identity;

namespace TDSTecnologia.Site.Core.Entities
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Telefone { get; set; }
    }
}
