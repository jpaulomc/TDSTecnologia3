using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TDSTecnologia.Site.Core.Entities;
using TDSTecnologia.Site.Infrastructure.Data;
using TDSTecnologia.Site.Infrastructure.Repository;

namespace TDSTecnologia.Site.Infrastructure.Services
{
    public class UsuarioService : BasicService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(AppContexto context, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager) : base(context)
        {
            _usuarioRepository = new UsuarioRepository(context, userManager, signInManager);
        }

        public async Task<IdentityResult> Salvar(Usuario usuario, string senha)
        {
           return await _usuarioRepository.Salvar(usuario,senha);
        }

        public async Task<IdentityResult> AdicionarPermissao(Usuario usuario, string permissao)
        {
            return await _usuarioRepository.AdicionarPermissao(usuario, permissao);
        }

        public async Task Login(Usuario usuario, bool lembrar)
        {
            await _usuarioRepository.Login(usuario, lembrar);
        }

        public async Task<Usuario> PesquisarUsuarioPeloEmail(string email)
        {
            return await _usuarioRepository.PesquisarUsuarioPeloEmail(email);
        }

        public async Task Logout()
        {
            await _usuarioRepository.Logout();
        }
    }
}
