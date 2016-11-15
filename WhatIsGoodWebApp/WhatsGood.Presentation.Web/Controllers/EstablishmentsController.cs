using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using WhatsGood.Crosscuting.Services.Ioc;
using WhatsGood.Domain.Repositories;
using WhatsGood.Presentation.Web.Models;

namespace WhatsGood.Presentation.Web.Controllers
{
    public class EstablishmentsController : ApiController
    {
        private readonly IUnitOfWork _wow;
        public EstablishmentsController()
        {
            _wow = DependencyInjector.Resolve<IUnitOfWork>();
        }

        public List<EstablishmentViewModel> Get()
        {
            return EstablishmentViewModel.Create( _wow.EstablishmentRepository.List());
        }

        public IHttpActionResult Get(int id)
        {
            var establishment = _wow.EstablishmentRepository.Find(id, "Type", "Address", "Contact", "Parking");
            if (establishment == null)
            {
                return NotFound();
            }
            return Ok ( EstablishmentFormViewModel.Create(establishment));
        }

        public IHttpActionResult Post(EstablishmentFormViewModel establishment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = EstablishmentFormViewModel.Create(establishment);
            if (entity.Type != null && entity.Type.Id > 0)
            {
                entity.Type = _wow.EstablishmentTypeRepository.Find(entity.Type.Id);
            }
            _wow.EstablishmentRepository.Add(entity);
            _wow.Save();
            return CreatedAtRoute("DefaultApi", new { id = entity.Id }, entity);
        }

     
        [HttpPut]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Edit(EstablishmentFormViewModel establishment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemExists = _wow.EstablishmentRepository.Find(establishment.EstablishmentId) != null;
            if (!itemExists)
            {
                return NotFound();
            }

            var entity = EstablishmentFormViewModel.Create(establishment);
            if (entity.Type != null && entity.Type.Id > 0)
            {
                entity.Type = _wow.EstablishmentTypeRepository.Find(entity.Type.Id);
            }
            _wow.EstablishmentRepository.Edit(entity);
            _wow.Save();
            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Delete(int id)
        {
            var establishment = _wow.EstablishmentRepository.Find(id);
            if (establishment == null)
            {
                return NotFound();
            }
            _wow.EstablishmentRepository.Remove(establishment);
            _wow.Save();
            return Ok(establishment);
        }
    }
}