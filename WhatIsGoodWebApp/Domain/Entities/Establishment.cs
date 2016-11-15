
using System.Collections.Generic;
using System.ComponentModel;

namespace WhatsGood.Domain.Entities
{
    public class Establishment : EntityBase
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public EstablishmentType Type { get; set; }
        public bool OwnParking { get; set; }
        public Parking Parking { get; set; }
        public string ImageUrl { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }
        public string WebSiteUrl { get; set; }
        public List<FileInformation> Photos { get; set; }
        public bool Accessibility { get; set; }
    }
}
