using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using WhatsGood.Crosscuting.Services.Ioc;
using WhatsGood.Domain.Entities;
using WhatsGood.Domain.Repositories;
using WhatsGood.Presentation.Web.Models;

namespace WhatsGood.Presentation.Web.Controllers
{
    public class EventsController : ApiController
    {
        private readonly IUnitOfWork _wow;
        public EventsController()
        {
            _wow = DependencyInjector.Resolve<IUnitOfWork>();
        }

        public List<EventViewModel> Get()
        {
            var events = _wow.EventRepository.GetNextEvents();

            return EventViewModel.Create(events);
        }

        public IHttpActionResult Get(int id)
        {
            var eventFound = _wow.EventRepository.Find(id, "Artist", "Establishment");
            if (eventFound == null)
            {
                return NotFound();
            }
            return Ok(EventFormViewModel.Create(eventFound)); 
        }


        [AcceptVerbs("POST")]
        public IHttpActionResult Post(EventFormViewModel eventVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = EventFormViewModel.Create(eventVm);
            SetAssociations(item);

            _wow.EventRepository.Add(item);
            _wow.Save();
            return CreatedAtRoute("DefaultApi", new { id = item.Id }, item);
        }

        private void SetAssociations(Event item)
        {
            if (item.Establishment != null)
            {
                item.Establishment = _wow.EstablishmentRepository.Find(item.Establishment.Id);
            }

            if (item.Artist != null)
            {
                item.Artist = _wow.ArtistRepository.Find(item.Artist.Id);
            }
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Edit(EventFormViewModel eventVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemExists = _wow.EventRepository.Find(eventVm.EventId) != null;
            if (!itemExists)
            {
                return NotFound();
            }

            var item = EventFormViewModel.Create(eventVm);

            SetAssociations(item);
            
            _wow.EventRepository.Edit(item);
            _wow.Save();

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Delete(int id)
        {
            var foundEvent = _wow.EventRepository.Find(id);
            if (foundEvent == null)
            {
                return NotFound();
            }
            _wow.EventRepository.Remove(foundEvent);
            _wow.Save();
            return Ok(foundEvent);
        }

    }
}