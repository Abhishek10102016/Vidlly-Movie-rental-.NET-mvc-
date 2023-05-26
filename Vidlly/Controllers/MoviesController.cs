using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidlly.Models;
using Vidlly.ViewModels;
using System.IO.MemoryMappedFiles;

namespace Vidlly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            //var movies = _context.Movies.Include(m => m.Genre).ToList();

            //return View(movies);
            if (User.IsInRole("CanManageMovies"))
                return View("List");
            else return View("ReadOnlyList");
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m =>m.Genre).SingleOrDefault(c => c.Id == id);
            if(movie == null)
            {
                return HttpNotFound();
            }
            return View(movie); 
        }
        [Authorize(Roles ="CanManageMovies")]
        public ActionResult New()
        {
            var genre = _context.Genre.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genre = genre,
            };
            return View("MovieForm", viewModel);
        }
        [Authorize(Roles = "CanManageMovies")]
        public ActionResult Edit(int id)
        {
           var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if(movie == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel(movie)
            {
                
                Genre = _context.Genre.ToList()
            };
            return View("MovieForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie) 
        {
            //Genre genre= _context.Genre.SingleOrDefault(c => c.Id ==movie.GenreId);
            //movie.Genre = genre;
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genre = _context.Genre.ToList()
                };

                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate= movie.ReleaseDate;   
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Movies" );
        }
    }
}