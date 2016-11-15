using WhatsGood.Domain.Entities;

namespace WhatsGood.Domain.Repositories
{
    public interface IEstablishmentTypeRepository : IBaseRepository<EstablishmentType>
    {
        EstablishmentType FindByName(string name);
    }
}
