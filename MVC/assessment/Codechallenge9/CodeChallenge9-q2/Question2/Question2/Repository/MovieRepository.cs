using Question2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Question2.Models;
    public class MovieRepository : IMovieRepository
{
    MovieDbContext db = new MovieDbContext();

    public List<Movie> GetAll()
    {
        return db.Movies.ToList();
    }

    public Movie GetById(int id)
    {
        return db.Movies.Find(id);
    }

    public void Add(Movie movie)
    {
        db.Movies.Add(movie);
        db.SaveChanges();
    }

    public void Update(Movie movie)
    {
        db.Entry(movie).State = EntityState.Modified;
        db.SaveChanges();
    }

    public void Delete(int id)
    {
        var movie = db.Movies.Find(id);
        db.Movies.Remove(movie);
        db.SaveChanges();
    }

    public List<Movie> GetByYear(int year)
    {
        return db.Movies
                 .Where(m => m.DateOfRelease.Year == year)
                 .ToList();
    }

    public List<Movie> GetByDirector(string name)
    {
        return db.Movies
                 .Where(m => m.DirectorName == name)
                 .ToList();
    }
}