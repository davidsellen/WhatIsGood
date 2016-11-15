namespace WhatsGood.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WhatsGood.Domain.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<WhatsGood.Repository.EventDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WhatsGood.Repository.EventDbContext context)
        {
            context.Genres.AddOrUpdate(
              g => g.Description,
              new Genre { Description = "Blues" },
              new Genre { Description = "Country" },
              new Genre { Description = "Eletrônica" },
              new Genre { Description = "Folk" },
              new Genre { Description = "Gospel" },
              new Genre { Description = "Jazz" },
              new Genre { Description = "Rap" },
              new Genre { Description = "Reggae" },
              new Genre { Description = "Rock'N'Roll" }
            );

            context.EstablishmentTypes.AddOrUpdate(
              g => g.Name,
              new EstablishmentType { Name = "Café" },
              new EstablishmentType { Name = "Casa de Shows" },
              new EstablishmentType { Name = "Bar" },
              new EstablishmentType { Name = "Boate" }
            );
        }
    }
}
