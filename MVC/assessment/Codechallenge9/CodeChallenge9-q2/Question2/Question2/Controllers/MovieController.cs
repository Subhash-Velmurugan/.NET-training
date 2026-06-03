using Question2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Question2.Controllers
{
    public class MoviesController : Controller
    {
        IMovieRepository repo = new MovieRepository();
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            repo.Add(movie);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            return View(repo.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            repo.Update(movie);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult MoviesByYear(int year)
        {
            var movies = repo.GetByYear(year);
            return View(movies);
        }
        public ActionResult MoviesByDirector(string name)
        {
            var movies = repo.GetByDirector(name);
            return View(movies);
        }
    }
}
