using Question2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IMovieRepository
{
    List<Movie> GetAll();
    Movie GetById(int id);
    void Add(Movie movie);
    void Update(Movie movie);
    void Delete(int id);
    List<Movie> GetByYear(int year);
    List<Movie> GetByDirector(string name);
}
