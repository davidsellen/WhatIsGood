using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatsGood.Crosscuting.Services.Ioc;
using WhatsGood.Domain.Entities;
using WhatsGood.Domain.Repositories;
using WhatsGood.Presentation.Web.Models;

namespace WhatsGood.Presentation.Web.Controllers
{
    public class ArtistsController : ApiController
    {
        private readonly IUnitOfWork _wow;
        public ArtistsController()
        {
            _wow = DependencyInjector.Resolve<IUnitOfWork>();
        }

        public List<ArtistViewModel> Get()
        {
            var artists = _wow.ArtistRepository.ListAllWithGenres().AsQueryable();
            return ArtistViewModel.Create(artists);
        }

        public IHttpActionResult Get(int id)
        {
            var entityFound = _wow.ArtistRepository.Find(id, "Genre");
            if (entityFound == null)
            {
                return NotFound();
            }
            return Ok(entityFound);
        }

        public IHttpActionResult Post(Artist artist)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            SetAssociations(artist);

            _wow.ArtistRepository.Add(artist);
            _wow.Save();
            return CreatedAtRoute("DefaultApi", new { id = artist.Id }, artist);
        }

        private void SetAssociations(Artist artist)
        {
            if (artist.Genre != null)
            {
                artist.Genre = _wow.GenreRepository.Find(artist.Genre.Id);
            }

        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Edit(int id, Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != artist.Id)
            {
                return BadRequest();
            }

            SetAssociations(artist);

            _wow.ArtistRepository.Edit(artist);
            try
            {
                _wow.Save();
            }
            catch (Exception)
            {
                var itemExists = _wow.EventRepository.Find(id) != null;
                if (!itemExists)
                {
                    return NotFound();
                }
                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Delete(int id)
        {
            var foundEntity = _wow.ArtistRepository.Find(id);
            if (foundEntity == null)
            {
                return NotFound();
            }
            _wow.ArtistRepository.Remove(foundEntity);
            _wow.Save();
            return Ok(foundEntity);
        }

    }
}