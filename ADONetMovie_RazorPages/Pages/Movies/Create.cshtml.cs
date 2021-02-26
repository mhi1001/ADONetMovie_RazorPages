using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace ADONetMovie_RazorPages.Pages.Movies
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Movie Movie { get; set; } = new Movie();
        public void OnGet(int aid)
        {
            Movie.ActorId = aid;
        }
        IMovieService movieService;
        public CreateModel(IMovieService service)
        {
            this.movieService = service;
        }
        public IActionResult OnPost(Movie Movie)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            movieService.AddMovie(Movie);
            return RedirectToPage("GetMovies");
        }
    }
}