using System.Configuration;

namespace WhatsGood.Repository
{
    public class DbContextFactory
    {

        public static string GetConnectionStrName()
        {
            return ConfigurationManager.AppSettings["WhatsGoodDBConnection"];            
        }

        public static EventDbContext CreateEventDb()
        {
            var connStrName = GetConnectionStrName();

            return new EventDbContext(connStrName);
        }
    }
}