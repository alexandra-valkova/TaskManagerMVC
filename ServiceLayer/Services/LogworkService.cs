using DataAccess.Entities;
using DataAccess.Repositories;

namespace ServiceLayer.Services
{
    public class LogworkService : BaseService<Logwork>
    {
        private LogworkRepository Repository { get; set; }

        public override BaseRepository<Logwork> CreateRepo()
        {
            return new LogworkRepository();
        }

        public LogworkService()
        {
            Repository = new LogworkRepository();
        }
    }
}