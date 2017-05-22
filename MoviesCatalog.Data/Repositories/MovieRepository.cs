using System.Collections.Generic;
using System.Linq;
using MoviesCatalog.Data.Infrastructure;
using System.Data.Entity;
using MoviesCatalog.Model;

namespace MoviesCatalog.Data.Repositories
{
    public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    {
        public MovieRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Movie GetMovieByName(string movieName)
        {
            return DbContext.Movie.FirstOrDefault(c => c.Name == movieName);
        }

        public IEnumerable<Movie> GetMovies(int page, int pageSize)
        {
            return DbContext
                .Movie
                .Include(m=>m.User)
                .OrderBy(m=>m.Id)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        //public override void Update(Movie entity)
        //{
        //    entity.Name = entity.Name;
        //    base.Update(entity);
        //}
    }

    public interface IMovieRepository : IRepository<Movie>
    {
        Movie GetMovieByName(string movieName);
        IEnumerable<Movie> GetMovies(int page, int pageSize);
    }
}
