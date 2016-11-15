using WhatsGood.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WhatsGood.Repository.Mappings
{
    public class EstablishmentMap : EntityTypeConfiguration<Establishment>
    {

        public EstablishmentMap()
        {
            this.HasKey(c => c.Id)
                .Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Name).IsRequired().HasMaxLength(150);
            this.Property(c => c.ImageUrl).HasMaxLength(250);
            this.Property(c => c.WebSiteUrl).HasMaxLength(250);
            this.Property(c => c.Accessibility);
            this.Property(c => c.Capacity);
            this.HasRequired(c => c.Address);
            this.HasOptional(c => c.Contact);
            this.HasOptional(c => c.Type);
            this.HasOptional(c => c.Parking);
            this.HasMany(c => c.Photos).WithMany().Map(m =>
            {
                m.MapLeftKey("EstablishmentId");
                m.MapRightKey("FileInformationId");
                m.ToTable("EstablishmentFiles");
            });
        }
    }
}
