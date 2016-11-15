using System;
using System.Collections.Generic;
using WhatsGood.Domain.Entities;


namespace WhatsGood.Domain.Repositories
{
    public interface IEventRepository : IBaseRepository<Event>
    {
        IEnumerable<Event> GetByStartDate(DateTime startDate);
        IEnumerable<Event> GetByGenre(Genre genre);
        IEnumerable<Event> GetNextEvents();
        IEnumerable<Event> GetByGenre(string genreDescription);
    }
}
