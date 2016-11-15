using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using WhatsGood.Crosscuting.Services.Ioc;
using WhatsGood.Domain.Entities;
using WhatsGood.Domain.Repositories;

namespace WhatsGood.Presentation.Web.Controllers
{
    public class EstablishmentTypesController : ApiController
    {
          private readonly IUnitOfWork _wow;
          public EstablishmentTypesController()
        {
            _wow = DependencyInjector.Resolve<IUnitOfWork>();
        }

        public IQueryable<EstablishmentType> Get()
        {
            return _wow.EstablishmentTypeRepository.List().AsQueryable();
        }

        public IHttpActionResult Get(int id)
        {
            var entityFound = _wow.EstablishmentTypeRepository.Find(id);
            if (entityFound == null)
            {
                return NotFound();
            }
            return Ok(entityFound); 
        }

        public IHttpActionResult Post(EstablishmentType establishmentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existent = _wow.EstablishmentTypeRepository.FindByName(establishmentType.Name);

            if (existent != null)
            {
                return BadRequest("O tipo informado já está cadastrado.");
            }

            _wow.EstablishmentTypeRepository.Add(establishmentType);
            _wow.Save();
            return CreatedAtRoute("DefaultApi", new { id = establishmentType.Id }, establishmentType);
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Edit(int id, EstablishmentType establishmentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != establishmentType.Id)
            {
                return BadRequest();
            }

            _wow.EstablishmentTypeRepository.Edit(establishmentType);
            try
            {
                _wow.Save();
            }
            catch (Exception)
            {
                var itemExists = _wow.EstablishmentTypeRepository.Find(id) != null;
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
            var foundEntity = _wow.EstablishmentTypeRepository.Find(id);
            if (foundEntity == null)
            {
                return NotFound();
            }
            _wow.EstablishmentTypeRepository.Remove(foundEntity);
            _wow.Save();
            return Ok(foundEntity);
        }

    }
}
