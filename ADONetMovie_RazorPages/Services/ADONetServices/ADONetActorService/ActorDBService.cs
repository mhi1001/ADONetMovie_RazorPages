using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services.ADONetActorService
{
    public class ActorDBService:IActorService
    {
        ADONetActorService _service;
        public ActorDBService(ADONetActorService service)
        {
            _service = service;
        }

        public void AddActor(Actor actor)
        {
            _service.AddActor(actor);
        }

        public void DeleteActor(Actor actor)
        {
            _service.DeleteActor(actor);
        }

        public Actor GetActorById(int id)
        {
           return  _service.GetActorById(id);
        }

        public IEnumerable<Actor> GetActors()
        {
          return   _service.GetActors();
        }

        public IEnumerable<Actor> GetActorsByCountry(string country)
        {
            throw new NotImplementedException();
        }
    }
}
