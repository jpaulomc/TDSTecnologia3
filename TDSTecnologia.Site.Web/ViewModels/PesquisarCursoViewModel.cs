
using System.Collections.Generic;
using TDSTecnologia.Site.Core.Entities;
using X.PagedList;

namespace TDSTecnologia.Site.Web.ViewModels
{
    public class CursoViewModel
    {
        public string Texto { get; set; }

        public IEnumerable<Curso> Cursos { get; set; }

        public IPagedList<Curso> CursosComPaginacao { get; set; }
    }
}
