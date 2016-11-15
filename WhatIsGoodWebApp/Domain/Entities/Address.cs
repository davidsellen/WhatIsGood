namespace WhatsGood.Domain.Entities
{
    public class Address : EntityBase
    {
        public string StreetName { get; set; }
        public string Complement { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public GeoPosition GeoPosition { get; set; }
    }
}