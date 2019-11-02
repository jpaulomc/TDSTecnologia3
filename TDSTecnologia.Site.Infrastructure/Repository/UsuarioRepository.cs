using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TDSTecnologia.Site.Core.Entities;
using TDSTecnologia.Site.Infrastructure.Data;

namespace TDSTecnologia.Site.Infrastructure.Repository
{
    class UsuarioRepository : BasicRepository
    {

        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;

        public UsuarioRepository(AppContexto context, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager) : base(context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> Salvar(Usuario usuario, string senha)
        {
            return await _userManager.CreateAsync(usuario, senha);
        }

        public async Task<IdentityResult> AdicionarPermissao(Usuario usuario, string permissao)
        {
           return await _userManager.AddToRoleAsync(usuario, permissao);
        }

        public async Task Login(Usuario usuario, bool lembrar)
        {
            await _signInManager.SignInAsync(usuario, lembrar);
        }

        public async Task<Usuario> PesquisarUsuarioPeloEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
