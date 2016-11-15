using System.Linq;
using WhatsGood.Domain.Entities;
using WhatsGood.Domain.Repositories;

namespace WhatsGood.Repository.Repositories
{
    public class EstablishmentTypeRepository : RepositoryBase<EstablishmentType>, IEstablishmentTypeRepository
    {

        public EstablishmentTypeRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public EstablishmentType FindByName(string name)
        {
            return this.CurrentSet.FirstOrDefault(e => e.Name == name);
        }
    }
}
