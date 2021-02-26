using ADONetMovie_RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services.Interfaces
{
   public  interface IActorService
    {
        IEnumerable<Actor> GetActors();
        void AddActor(Actor actor);
        IEnumerable<Actor> GetActorsByCountry(string country);
        public Actor GetActorById(int id);
        public void DeleteActor(Actor actor);

    }
}
