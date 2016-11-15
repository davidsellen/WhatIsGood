using WhatsGood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsGood.Repository.Mappings
{
    public class ArtistMap : EntityTypeConfiguration<Artist>
    {
        public ArtistMap()
        {
            this.HasKey(a => a.Id)
                .Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(a => a.Name).HasMaxLength(200);
            this.Property(a => a.Email).HasMaxLength(200);
            this.Property(a => a.PhotoUrl).HasMaxLength(200);
            this.Property(a => a.WebSiteUrl).HasMaxLength(200);
            this.Property(a => a.CountryName).HasMaxLength(100);

            this.HasOptional(a => a.Genre);
        }
    }
}

