using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesCatalog.Model;

namespace MoviesCatalog.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        MoviesCatalogEntities Init();
    }
}
