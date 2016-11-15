using WhatsGood.Domain.Entities;
using WhatsGood.Domain.Repositories;

namespace WhatsGood.Repository.Repositories
{
    public class FileInformationRepository : RepositoryBase<FileInformation>, IFileInformationRepository
    {

        public FileInformationRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
