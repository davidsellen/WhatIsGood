using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WhatsGood.Domain.Entities;

namespace WhatsGood.Repository.Mappings
{
    public class ParkingMap : EntityTypeConfiguration<Parking>
    {
        public ParkingMap()
        {
            this.HasKey(c => c.Id)
                .Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Price).IsRequired();
            this.Property(c => c.Capacity).IsRequired();            
        }
    }
}