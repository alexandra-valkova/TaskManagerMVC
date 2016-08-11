using DataAccess.Entities;
using DataAccess.Repositories;

namespace ServiceLayer.Services
{
    public class UserService : BaseService<User>
    {
        private UserRepository Repository { get; set; }

        public override BaseRepository<User> CreateRepo()
        {
            return new UserRepository();
        }

        public UserService()
        {
            Repository = new UserRepository();
        }
    }
}