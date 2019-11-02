
using TDSTecnologia.Site.Core.Entities;

namespace TDSTecnologia.Site.Web.ViewModels
{
    public class CadastroUsuarioViewModel
    {
        public string Email { get; set; }

        public string Senha { get; set; }

        public string Nome { get; set; }

        public string NomeUsuario { get; set; }

        public string CPF { get; set; }

        public string Telefone { get; set; }

        public Usuario ConverterParaUsuario()
        {
            return new Usuario()
            {
                Email = this.Email,
                UserName = this.NomeUsuario,
                CPF = this.CPF,
                PasswordHash = this.Senha,
                Telefone = this.Telefone,
                Nome = this.Nome
            };
        }
    }
}
