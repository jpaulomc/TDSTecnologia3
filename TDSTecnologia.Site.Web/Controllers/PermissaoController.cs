using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDSTecnologia.Site.Core.Entities;
using TDSTecnologia.Site.Infrastructure.Services;

namespace TDSTecnologia.Site.Web.Controllers
{
    public class PermissaoController : Controller
    {
        private readonly PermissaoService _permissaoService;

        public PermissaoController(PermissaoService permissaoService)
        {
            _permissaoService = permissaoService;
        }

        public IActionResult Index()
        {
            List<Permissao> permissoes = _permissaoService.ListarTodos();
            return View("Index", permissoes);
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View("Novo");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Novo([Bind("Descricao,Name")] Permissao permissao)
        {
            if (ModelState.IsValid)
            {
                bool existePermissao = await _permissaoService.ExistePermissao(permissao.Name);

                if (!existePermissao)
                {
                    permissao.NormalizedName = permissao.Name.ToUpper();
                    await _permissaoService.Salvar(permissao);
                    return RedirectToAction("Index", "Permissao");
                }
            }
            return View(permissao);
        }

        public IActionResult Alterar(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permissao = _permissaoService.PesquisarPorId(id);
            if (permissao == null)
            {
                return NotFound();
            }
            return View(permissao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Alterar(string id, [Bind("Descricao,Id,Name,NormalizedName,ConcurrencyStamp")] Permissao permissao)
        {
            if (id != permissao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _permissaoService.Atualizar(permissao);
                return RedirectToAction("Index", "Permissao");

            }
            return View(permissao);
        }

        [HttpDelete]
        public IActionResult Excluir(string id)
        {
            _permissaoService.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
