

namespace WhatsGood.Domain.Entities
{
    public class Artist : EntityBase
    {
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public string CountryName { get; set; }
        public string PhotoUrl { get; set; }
        public string WebSiteUrl { get; set; }
        public string Email { get; set; }
    }
}
