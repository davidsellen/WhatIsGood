using WhatsGood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsGood.Domain.Repositories;

namespace WhatsGood.Repository
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {

        public EventRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public IEnumerable<Event> GetByStartDate(DateTime startDate)
        {
            return CurrentSet.Include("Establishment")
                             .Include("Artist")
                             .Include("Artist.Genre")
                             .Where(e => e.StartDate.Day == startDate.Day &&
                                         e.StartDate.Month == startDate.Month &&
                                         e.StartDate.Year == startDate.Year);
        }

        public IEnumerable<Event> GetByGenre(Genre genre)
        {
            return CurrentSet.Where(e => e.Artist.Genre.Id == genre.Id);
        }

        public IEnumerable<Event> GetNextEvents()
        {
            var startDate = DateTime.Today;
            return CurrentSet.Include("Establishment")
                             .Include("Artist")
                             .Include("Artist.Genre")
                             .Where(e => e.StartDate.Day >= startDate.Day &&
                                         e.StartDate.Month >= startDate.Month &&
                                         e.StartDate.Year >= startDate.Year)
                             .OrderBy(e => e.StartDate);
        }

        public IEnumerable<Event> GetByGenre(string genreDescription)
        {
            return CurrentSet.Where(e => e.Artist.Genre.Description == genreDescription);
        }

    }
}
