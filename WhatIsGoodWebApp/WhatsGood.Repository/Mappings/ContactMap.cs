using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WhatsGood.Domain.Entities;

namespace WhatsGood.Repository.Mappings
{
    public class ContactMap : EntityTypeConfiguration<Contact>
    {
        public ContactMap()
        {
            this.HasKey(a => a.Id)
                .Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(a => a.EmailAddress).HasMaxLength(200);
            this.Property(a => a.FirstName).HasMaxLength(100);
            this.Property(a => a.LastName).HasMaxLength(200);
            this.Property(a => a.PhoneNumber).HasMaxLength(30);
            this.Property(a => a.BirthDate).IsOptional();
        }
    }
}