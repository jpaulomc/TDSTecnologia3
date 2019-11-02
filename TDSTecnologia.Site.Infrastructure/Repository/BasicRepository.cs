using TDSTecnologia.Site.Infrastructure.Data;

namespace TDSTecnologia.Site.Infrastructure.Repository
{
    public class BasicRepository
    {
        protected readonly AppContexto _context;

        public BasicRepository(AppContexto context)
        {
            _context = context;
        }
    }
}
