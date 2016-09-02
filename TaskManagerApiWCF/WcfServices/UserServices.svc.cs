using DataAccess.Entities;
using ServiceLayer.Services;
using TaskManagerApiWCF.Models;

namespace TaskManagerApiWCF.WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserServices.svc or UserServices.svc.cs at the Solution Explorer and start debugging.
    public class UserServices : BaseServices<User, UserModel>
    {
        public override BaseService<User> CreateService()
        {
            return new UserService();
        }

        public override User PopulateEntity(UserModel model)
        {
            return new User()
            {
                ID = model.ID,
                Username = model.Username,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName,
                IsAdmin = model.IsAdmin
            };
        }

        public override UserModel PopulateModel(User user)
        {
            return new UserModel()
            {
                ID = user.ID,
                Username = user.Username,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsAdmin = user.IsAdmin
            };
        }
    }
}