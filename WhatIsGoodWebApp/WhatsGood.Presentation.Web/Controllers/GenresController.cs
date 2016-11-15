using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatsGood.Crosscuting.Services.Ioc;
using WhatsGood.Domain.Entities;
using WhatsGood.Domain.Repositories;

namespace WhatsGood.Presentation.Web.Controllers
{
    public class GenresController : ApiController
    {
          private readonly IUnitOfWork _wow;
          public GenresController()
        {
            _wow = DependencyInjector.Resolve<IUnitOfWork>();
        }

        public IQueryable<Genre> Get()
        {
            return _wow.GenreRepository.List().AsQueryable();
        }

        public IHttpActionResult Get(int id)
        {
            var genreFound = _wow.GenreRepository.Find(id);
            if (genreFound == null)
            {
                return NotFound();
            }
            return Ok(genreFound); 
        }

        public IHttpActionResult Post(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alreadyExists = _wow.GenreRepository.List().Any(g => g.Description == genre.Description);

            if (alreadyExists)
            {
                return BadRequest("O gênero informado já está cadastrado.");
            }

            _wow.GenreRepository.Add(genre);
            _wow.Save();
            return CreatedAtRoute("DefaultApi", new { id = genre.Id }, genre);
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Edit(int id, Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != genre.Id)
            {
                return BadRequest();
            }

            _wow.GenreRepository.Edit(genre);
            try
            {
                _wow.Save();
            }
            catch (Exception)
            {
                var itemExists = _wow.GenreRepository.Find(id) != null;
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
            var foundGenre = _wow.GenreRepository.Find(id);
            if (foundGenre == null)
            {
                return NotFound();
            }
            _wow.GenreRepository.Remove(foundGenre);
            _wow.SaveAsync();
            return Ok(foundGenre);
        }

    }
}
