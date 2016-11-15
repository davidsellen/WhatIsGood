using WhatsGood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsGood.Domain.Repositories;

namespace WhatsGood.Repository.Repositories
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
         
         public GenreRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
