using System;
using WhatsGood.Domain.Entities;

namespace WhatsGood.Presentation.Web.Models
{
    [Serializable]
    public class EventFormViewModel
    {
        public int EventId { get; set; }
        public string Description { get; set; }
        public int ArtistId { get; set; }
        public int EstablishmentId { get; set; }
        public decimal EventPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public static EventFormViewModel Create(Event @event)
        {
            return new EventFormViewModel
            {
                EventId = @event.Id,
                Description = @event.Description,
                EventPrice = @event.FullPrice,
                StartDate = @event.StartDate,
                EndDate = @event.EndDate,
                ArtistId = @event.Artist != null ? @event.Artist.Id : 0,
                EstablishmentId = @event.Establishment != null ? @event.Establishment.Id : 0
            };
        }

        public static Event Create(EventFormViewModel eventVm)
        {
            return new Event
            {
                Id = eventVm.EventId,
                Description = eventVm.Description,
                FullPrice = eventVm.EventPrice,
                StartDate = eventVm.StartDate,
                EndDate = eventVm.EndDate,
                Artist = eventVm.ArtistId != 0 ? new Artist { Id = eventVm.ArtistId } : null,
                Establishment = eventVm.EstablishmentId != 0 ? new Establishment { Id = eventVm.EstablishmentId } : null
            };
        }
    }
}