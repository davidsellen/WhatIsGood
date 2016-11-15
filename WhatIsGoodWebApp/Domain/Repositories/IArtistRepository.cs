using System;
using System.Collections.Generic;
using WhatsGood.Domain.Entities;


namespace WhatsGood.Domain.Repositories
{
    public interface IArtistRepository : IBaseRepository<Artist>
    {
        List<Artist> ListAllWithGenres();
    }
}
