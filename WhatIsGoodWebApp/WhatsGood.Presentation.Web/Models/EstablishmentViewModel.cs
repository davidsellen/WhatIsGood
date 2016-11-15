using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using WhatsGood.Domain.Entities;

namespace WhatsGood.Presentation.Web.Models
{
    [Serializable]
    public class EstablishmentViewModel
    {
        public int EstablishmentId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string WebSiteUrl { get; set; }

        public static List<EstablishmentViewModel> Create(IEnumerable<Establishment> establishments)
        {
            var s = from e in establishments
                select new EstablishmentViewModel
                {
                    EstablishmentId = e.Id,
                    Name = e.Name,
                    ImageUrl = e.ImageUrl,
                    WebSiteUrl = e.WebSiteUrl
                };
            return s.ToList();
        }
    }
}