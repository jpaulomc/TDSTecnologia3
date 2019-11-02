
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDSTecnologia.Site.Core.Entities;
using TDSTecnologia.Site.Infrastructure.Data;
using TDSTecnologia.Site.Infrastructure.Repository;

namespace TDSTecnologia.Site.Infrastructure.Services
{
    public class PermissaoService : BasicService
    {
        private readonly PermissaoRepository _permissaoRepository;

        public PermissaoService(AppContexto contexto, RoleManager<Permissao> roleManager) : base(contexto)
        {
            _permissaoRepository = new PermissaoRepository(contexto, roleManager);
        }

        public async Task<bool> ExistePermissao(string permissao)
        {
            return await _permissaoRepository.ExistePermissao(permissao);
        }

        public Task<IdentityResult> Salvar(Permissao permissao)
        {
            Task<IdentityResult> result = _permissaoRepository.Salvar(permissao);
            SaveChangesApp();
            return result;
        }

        public List<Permissao> ListarTodos()
        {
            return _permissaoRepository.ListarTodos(); ;
        }

        public Permissao PesquisarPorId(string id)
        {
            return _permissaoRepository.PesquisarPorId(id);
        }

        public void Atualizar(Permissao permissao)
        {
            _permissaoRepository.Atualizar(permissao);
            SaveChangesApp();
        }

        public void Excluir(string id)
        {
            _permissaoRepository.Excluir(PesquisarPorId(id));
            SaveChangesApp();
        }
    }
}
