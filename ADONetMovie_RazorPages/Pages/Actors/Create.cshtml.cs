using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace ADONetMovie_RazorPages.Pages.Actors
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Actor Actor { get; set; } = new Actor();
        public void OnGet(int id)
        {
            Actor.Id = id;
        }
        IActorService actorService;
        public CreateModel(IActorService  service)
        {
           actorService = service;
        }
        public IActionResult OnPost(Actor Actor)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            actorService.AddActor(Actor);
            return RedirectToPage("GetActors");
        }
    }
}