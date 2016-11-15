using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WhatsGood.Domain.Entities;

namespace WhatsGood.Repository.Mappings
{
    public class EstablishmentTypeMap : EntityTypeConfiguration<EstablishmentType>
    {

        public EstablishmentTypeMap()
        {
            this.HasKey(c => c.Id)
                .Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Name).IsRequired()
                .HasMaxLength(50);
        }
    }
}