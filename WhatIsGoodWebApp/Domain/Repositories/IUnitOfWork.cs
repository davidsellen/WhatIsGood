using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsGood.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IArtistRepository ArtistRepository { get; }
        IEventRepository EventRepository { get; }
        IEstablishmentRepository EstablishmentRepository { get; }
        IGenreRepository GenreRepository { get; }
        IEstablishmentTypeRepository EstablishmentTypeRepository { get; }
        IFileInformationRepository FileInformationRepository { get; }
        Task<int> SaveAsync();
        void Save();
    }
}
