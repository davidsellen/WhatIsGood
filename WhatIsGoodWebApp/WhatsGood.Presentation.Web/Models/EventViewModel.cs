using System;
using System.Collections.Generic;
using WhatsGood.Domain.Entities;

namespace WhatsGood.Presentation.Web.Models
{
    [Serializable]
    public class EventViewModel
    {
        public int EventId { get; set; }
        public string Description { get; set; }
        public string EventAddress { get; set; }
        public string PromoterName { get; set; }
        public string ArtistName { get; set; }
        public string GenreName { get; set; }
        public decimal EventPrice { get; set; }
        public DateTime StartDate { get; set; }

        public static List<EventViewModel> Create(IEnumerable<Event> events)
        {
            var eventList = new List<EventViewModel>();
            foreach (var @event in events)
            {
                var eventVm = new EventViewModel
                {
                    Description = @event.Description,
                    EventId = @event.Id,
                    StartDate = @event.StartDate,
                    EventPrice = @event.FullPrice
                };
                var artist = @event.Artist;
                if (artist != null)
                {
                    eventVm.ArtistName = artist.Name;
                    var genre = artist.Genre;
                    if (genre != null)
                        eventVm.GenreName = genre.Description;
                }

                var promoter = @event.Establishment;
                if (promoter != null)
                {
                    eventVm.PromoterName = promoter.Name;
                    if (promoter.Address != null)
                    {
                        eventVm.EventAddress =string.Concat(promoter.Address.StreetName ,", ", promoter.Address.Complement);
                    }
                }
                eventList.Add(eventVm);
            }

            return eventList;
        }
    }
}