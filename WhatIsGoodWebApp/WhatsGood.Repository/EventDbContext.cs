using System;
using System.Data.Entity.SqlServer;
using System.Data.Entity.Validation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WhatsGood.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WhatsGood.Domain.Repositories;
using WhatsGood.Repository.Mappings;
using System.Data.Entity.Infrastructure;
using WhatsGood.Repository.Repositories;

namespace WhatsGood.Repository
{
    public class MigrationsContextFactory : IDbContextFactory<EventDbContext>
    {
        public EventDbContext Create()
        {
            return DbContextFactory.CreateEventDb();
        }
    }

    public class CustomDbConfiguration : DbConfiguration
    {
        public CustomDbConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            SetDefaultConnectionFactory(new LocalDbConnectionFactory("v11.0"));
        }
    }

    [DbConfigurationType(typeof(CustomDbConfiguration))] 
    public class EventDbContext : DbContext, IUnitOfWork
    {
        public EventDbContext(string conn)
            : base(conn)
        {
          
          Database.SetInitializer(new MigrateDatabaseToLatestVersion<EventDbContext, Migrations.Configuration>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<EventDbContext>());

        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Establishment> Establishments { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<FileInformation> FileInformations { get; set; }
        public DbSet<EstablishmentType> EstablishmentTypes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            modelBuilder.Configurations.Add(new GenreMap());
            modelBuilder.Configurations.Add(new ArtistMap());
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new ContactMap());
            modelBuilder.Configurations.Add(new EstablishmentTypeMap());
            modelBuilder.Configurations.Add(new FileInformationMap());
            modelBuilder.Configurations.Add(new ParkingMap());
            modelBuilder.Configurations.Add(new EstablishmentMap());
            modelBuilder.Configurations.Add(new EventMap());

            base.OnModelCreating(modelBuilder);
        }

        #region IUnitOfWork Impl

        private IArtistRepository _artistRepository;
        private IEventRepository _eventRepository;
        private IEstablishmentRepository _establishmentRepository;
        private IEstablishmentTypeRepository _establishmentTypeRepository;
        private IGenreRepository _genreRepository;
        private IFileInformationRepository _fileInformationRepository;
        public IArtistRepository ArtistRepository
        {
            get { return _artistRepository ?? (_artistRepository = new ArtistRepository(this)); }
        }
        public IEventRepository EventRepository
        {
            get { return _eventRepository ?? (_eventRepository = new EventRepository(this)); }
        }
        public IEstablishmentRepository EstablishmentRepository
        {
            get { return _establishmentRepository ?? (_establishmentRepository = new EstablishmentRepository(this)); }
        }
        public IGenreRepository GenreRepository
        {
            get { return _genreRepository ?? (_genreRepository = new GenreRepository(this)); }
        }
        public IFileInformationRepository FileInformationRepository
        {
            get { return _fileInformationRepository ?? (_fileInformationRepository = new FileInformationRepository(this)); }
        }
        public IEstablishmentTypeRepository EstablishmentTypeRepository
        {
            get { return _establishmentTypeRepository ?? (_establishmentTypeRepository = new EstablishmentTypeRepository(this)); }
        }

        public void Save()
        {
            SetAuditInfo();
            try
            {
                base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sbErrors = new StringBuilder();
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    sbErrors.Append(validationErrors.GetType());
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        sbErrors.AppendFormat("Property {0}: {1}", validationError.PropertyName,
                            validationError.ErrorMessage);
                        System.Diagnostics.Trace.TraceInformation("Property: {0} Error: {1}",
                            validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                throw new Exception(sbErrors.ToString());
            }

        }

        private void SetAuditInfo()
        {
            NetworkCredential cred = CredentialCache.DefaultNetworkCredentials;
            var currentUser = cred == null || string.IsNullOrEmpty(cred.UserName) ? "ADMIN" : cred.UserName;
            foreach (var entity in ChangeTracker.Entries<EntityBase>())
            {
                if (entity.State != EntityState.Added && entity.State != EntityState.Modified) continue;

                entity.Entity.UpdatedDate = DateTime.Now;
                entity.Entity.UpdatedBy = currentUser;

                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedDate = DateTime.Now;
                    entity.Entity.CreatedBy = currentUser;
                }
                else
                {
                    entity.Property(p => p.CreatedDate).IsModified = false;
                    entity.Property(p => p.CreatedBy).IsModified = false;
                }
            }
        }

        public Task<int> SaveAsync()
        {
            SetAuditInfo();
            return base.SaveChangesAsync();
        }

        #endregion

        public static void SetInitializer()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EventDbContext, Migrations.Configuration>());
        }
    }
}
