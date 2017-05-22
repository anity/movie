using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MoviesCatalog.Model;
using MoviesCatalog.Service;
using MoviesCatalog.Web.ViewModels;
using WebMatrix.WebData;

namespace MoviesCatalog.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private const int DefaultPageSize = 10;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public ActionResult Index(int page = 1)
        {
            var movies = _movieService.GetMovies(page-1, DefaultPageSize);
            var viewModelMovies = Mapper.Map<IEnumerable<Movie>, IEnumerable<MovieViewModel>>(movies);
            var model = new MoviesViewModel(viewModelMovies, 
                new PageInfo(page, DefaultPageSize, _movieService.Count()));

            if (Request.IsAjaxRequest())
                return PartialView("Partials/_MoviesContent", model);
            return View(model);
        }

        public ActionResult Movie(int id = 0)
        {
            MovieViewModel model = null;
            if (id > 0)
            {
                model = Mapper.Map<Movie, MovieViewModel>(_movieService.GetMovie(id));
            }
            else
            {
                model = new MovieViewModel();
            }
            return View(model);
        }

        public ActionResult EditMovie(int id = 0)
        {
            MovieViewModel model = null;
            if (WebSecurity.IsAuthenticated)
            {
                if (id > 0)
                {
                    var movie = _movieService.GetMovie(id);
                    if (movie != null && movie.UserId == WebSecurity.CurrentUserId)
                        model = Mapper.Map<Movie, MovieViewModel>(movie);
                    else
                        return RedirectToAction("Index");
                }
                else
                {
                    model = new MovieViewModel(WebSecurity.CurrentUserId, WebSecurity.CurrentUserName);
                }
            }


            return View(model);
        }

        [HttpPost]
        public ActionResult SaveMovie(MovieViewModel movie, HttpPostedFileBase image)
        {
            if (movie.Id > 0 && image != null && !string.IsNullOrEmpty(movie.ImageName) &&
                System.IO.File.Exists(Server.MapPath("/imgdb/" + movie.ImageName)))
            {
                System.IO.File.Delete(Server.MapPath("/imgdb/" + movie.ImageName));

                var imgName = DateTime.Now.ToString("yyyyMMdd-HHmmssff") + Path.GetExtension(image.FileName);
                var path = Path.Combine(Server.MapPath("~/imgdb/"), imgName);
                image.SaveAs(path);
                movie.ImageName = imgName;
            }


            if(movie.Id==0)
                _movieService.CreateMovie(Mapper.Map<MovieViewModel, Movie>(movie));
            else
                _movieService.UpdateMovie(Mapper.Map<MovieViewModel, Movie>(movie));
           
            return RedirectToAction("Index");
        }
    }
}
