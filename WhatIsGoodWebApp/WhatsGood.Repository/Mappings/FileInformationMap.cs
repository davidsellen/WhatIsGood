using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WhatsGood.Domain.Entities;

namespace WhatsGood.Repository.Mappings
{
    public class FileInformationMap : EntityTypeConfiguration<FileInformation>
    {

        public FileInformationMap()
        {
            this.HasKey(c => c.Id)
                .Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Name).IsRequired().HasMaxLength(100);
            this.Property(c => c.Url).HasMaxLength(300);
            this.Property(c => c.Extension).HasMaxLength(5);
            this.Property(c => c.Description).HasMaxLength(250);
        }
    }
}