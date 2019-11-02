using Microsoft.AspNetCore.Identity;

namespace TDSTecnologia.Site.Core.Entities
{
    public class Permissao : IdentityRole
    {
        public string Descricao { get; set; }
    }
}
