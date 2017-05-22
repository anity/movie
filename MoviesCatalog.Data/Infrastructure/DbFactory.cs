
using MoviesCatalog.Model;

namespace MoviesCatalog.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        MoviesCatalogEntities dbContext;

        public MoviesCatalogEntities Init()
        {
            return dbContext ?? (dbContext = new MoviesCatalogEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
