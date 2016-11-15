using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using WhatsGood.Domain.Entities;

namespace WhatsGood.Presentation.Web.Models
{
    [Serializable]
    public class ArtistViewModel
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public string GenreDescription { get; set; }
        public string CountryName { get; set; }
        public string PhotoUrl { get; set; }
        public string WebSiteUrl { get; set; }
        public string Email { get; set; }

        public static List<ArtistViewModel> Create(IEnumerable<Artist> artists)
        {

            var vm = from art in artists
                select new ArtistViewModel()
                {
                    ArtistId = art.Id,
                    Name = art.Name,
                    CountryName = art.CountryName,
                    GenreId = art.Genre != null ? art.Genre.Id : 0,
                    GenreDescription = art.Genre != null ? art.Genre.Description : string.Empty,
                    Email = art.Email,
                    PhotoUrl = art.PhotoUrl,
                    WebSiteUrl = art.WebSiteUrl
                };

            return vm.ToList();
        }
    }
}