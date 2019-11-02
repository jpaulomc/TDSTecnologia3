using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDSTecnologia.Site.Core.Entities;
using TDSTecnologia.Site.Infrastructure.Constants;
using TDSTecnologia.Site.Infrastructure.Data;
using X.PagedList;


namespace TDSTecnologia.Site.Infrastructure.Repository
{
    public class CursoRespository : BasicRepository
    {

        public CursoRespository(AppContexto context) : base(context)
        {
        }

        public List<Curso> ListarTodos()
        {
            return _context.CursoDao.ToList();
        }

        public IPagedList<Curso> ListarComPaginacao(int? pagina)
        {
            int numeroPagina = (pagina ?? 1);
            IPagedList<Curso> cursosPaginacao = _context.CursoDao.ToPagedList( numeroPagina, Parametros.ITENS_POR_PAGINA);
            return cursosPaginacao;
        }

        public void Salvar(Curso curso)
        {
            _context.Add(curso);
        }

        public Curso PesquisarPorId(int? id)
        {
            return _context.CursoDao.Find(id);
        }

        public List<Curso> PesquisarPorNomeDescricao(string texto)
        {
            List<Curso> cursos = _context.CursoDao.Where(x => EF.Functions.ILike(x.Nome, $"%{texto}%") || EF.Functions.ILike(x.Descricao, $"%{texto}%")).OrderBy(x => x.Nome).ToList();

            return cursos;
        }

        public void Atualizar(Curso curso)
        {
            _context.Update(curso);
            _context.Entry<Curso>(curso).Property(c => c.Banner).IsModified = false;
        }

        public void Excluir(Curso curso)
        {
            _context.CursoDao.Remove(curso);
        }

    }
}
