using System.Data.Entity;
using System.Data.Entity.Core;
using WhatsGood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsGood.Domain.Repositories;

namespace WhatsGood.Repository.Repositories
{
    public class EstablishmentRepository : RepositoryBase<Establishment>, IEstablishmentRepository
    {
        public EstablishmentRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public new void Edit(Establishment establishment)
        {
            if (establishment == null) throw new ArgumentNullException("establishment");

            var dbEstablishment = Find(establishment.Id, "Address", "Contact");

            if (dbEstablishment == null) throw new ObjectNotFoundException();

            Context.Entry(dbEstablishment).CurrentValues.SetValues(establishment);
            
            if (dbEstablishment.Contact == null)
                dbEstablishment.Contact = new Contact();

            if (establishment.Contact != null)
            {
                Context.Entry(dbEstablishment.Contact).CurrentValues.SetValues(establishment.Contact);
            }

            if (dbEstablishment.Address == null)
                dbEstablishment.Address =new Address();

            if (establishment.Address != null)
            {
                Context.Entry(dbEstablishment.Address).CurrentValues.SetValues(establishment.Address);
            }


            if (dbEstablishment.Parking == null)
                dbEstablishment.Parking = new Parking();

            if (establishment.Parking != null)
            {
                Context.Entry(dbEstablishment.Parking).CurrentValues.SetValues(establishment.Parking);
            }
        }
    }
}
