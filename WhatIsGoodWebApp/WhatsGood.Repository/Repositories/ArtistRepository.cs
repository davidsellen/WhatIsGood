using WhatsGood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsGood.Domain.Repositories;

namespace WhatsGood.Repository.Repositories
{
    public class ArtistRepository : RepositoryBase<Artist>, IArtistRepository
    { 

         public ArtistRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public List<Artist> ListAllWithGenres()
        {
            return CurrentSet.Include("Genre").ToList();
        }
    }
}
