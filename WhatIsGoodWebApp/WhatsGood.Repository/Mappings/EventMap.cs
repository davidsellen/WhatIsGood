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
    public class EventMap : EntityTypeConfiguration<Event>
    {
        public EventMap()
        {
            this.HasKey(e => e.Id);
            this.Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(e => e.Description).HasMaxLength(200);
            this.Property(e => e.StartDate);
            this.Property(e => e.EndDate);
            this.Property(e => e.FullPrice); 
            this.HasRequired(e => e.Artist);
            this.HasOptional(e => e.Establishment);
        }
    }
}
