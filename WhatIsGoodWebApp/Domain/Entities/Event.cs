
using System;
namespace WhatsGood.Domain.Entities
{
    public class Event : EntityBase 
    {
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal FullPrice { get; set; }        
        public Artist Artist { get; set; }
        public Establishment Establishment { get; set; }
    }
}
