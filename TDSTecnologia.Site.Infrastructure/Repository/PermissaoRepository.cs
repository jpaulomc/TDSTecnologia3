using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDSTecnologia.Site.Core.Entities;
using TDSTecnologia.Site.Infrastructure.Data;

namespace TDSTecnologia.Site.Infrastructure.Repository
{
    public class PermissaoRepository : BasicRepository
    {
        private readonly RoleManager<Permissao> _roleManager;

        public PermissaoRepository(AppContexto contexto, RoleManager<Permissao> roleManager) : base(contexto)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> ExistePermissao(string permissao)
        {
            return await _roleManager.RoleExistsAsync(permissao);
        }

        public Task<IdentityResult> Salvar(Permissao permissao)
        {
           return _roleManager.CreateAsync(permissao);
        }

        public List<Permissao> ListarTodos()
        {
            return _context.Permissoes.ToList();
        }

        public Permissao PesquisarPorId(string id)
        {
            return _context.Permissoes.Find(id);
        }

        public  void Atualizar(Permissao permissao)
        {
           _context.Update(permissao);
        }

        public void Excluir(Permissao permissao)
        {
            _roleManager.DeleteAsync(permissao);
        }

    }
}
