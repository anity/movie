using System.Collections.Generic;
using System.Linq;
using MoviesCatalog.Data.Repositories;
using MoviesCatalog.Model;

namespace MoviesCatalog.Service
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetMovies(int page, int pageSize);
        Movie GetMovie(int id);
        void CreateMovie(Movie movie);
        void UpdateMovie(Movie movie);
        int Count();
    }

    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _moviesRepository;

        public MovieService(IMovieRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public IEnumerable<Movie> GetMovies(int page, int pageSize)
        {
            return _moviesRepository.GetMovies(page, pageSize);
        }

        public Movie GetMovie(int id)
        {
            return _moviesRepository.GetById(id);
        }

        public void CreateMovie(Movie movie)
        {
            _moviesRepository.Add(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            _moviesRepository.Update(movie);
        }

        public int Count()
        {
            return _moviesRepository.Count();
        }
    }
}
