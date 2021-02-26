using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services.ADONetServices.ADONetMovieService
{
    public class MovieDBService : IMovieService
    {
        ADONetMovieService _service;
        public MovieDBService(ADONetMovieService service)
        {
            _service = service;
        }

        public void AddMovie(Movie movie)
        {
            _service.AddMovie(movie);
        }

        public void DeleteMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void DeleteMoviesByActorId(Actor actor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> FilterMoviesByTitle(string filter)
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMovies()
        {
          return   _service.GetMovies();
        }

        public IEnumerable<Movie> GetMoviesByActor(int aid)
        {
            throw new NotImplementedException();
        }
    }
}
