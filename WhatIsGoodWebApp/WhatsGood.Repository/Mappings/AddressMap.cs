using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WhatsGood.Domain.Entities;

namespace WhatsGood.Repository.Mappings
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {

        public AddressMap()
        {
            this.HasKey(c => c.Id)
                .Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); ;
            this.Property(c => c.StreetName).HasMaxLength(300);
            this.Property(c => c.PostalCode).HasMaxLength(20);
            this.Property(c => c.Province).HasMaxLength(150);
            this.Property(c => c.Country).HasMaxLength(200);
            this.Property(c => c.City).HasMaxLength(200);
            this.Property(c => c.Complement).HasMaxLength(200);
            this.Property(c => c.District).HasMaxLength(150); 

        }
    }
}