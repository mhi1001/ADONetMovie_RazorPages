using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADONetMovie_RazorPages
{
    public class DeleteModel : PageModel
    {
        IActorService actorService;
        IMovieService movieService;

        public DeleteModel(IActorService service , IMovieService  mservice )
        {
            this.actorService = service;
            movieService = mservice;
        }
        [BindProperty]
        public Actor Actor { get; set; }

        public IActionResult OnGet(int id)
        {
            Actor = actorService.GetActorById(id);
            return Page();
        }
        public IActionResult OnPost()
        {
            actorService.DeleteActor(Actor);

           // movieService.DeleteMoviesByActorId(Actor);

            return RedirectToPage("GetActors");
        }
    }
}