using DataAccess.Entities;
using ServiceLayer.Services;
using TaskManagerMVC.ViewModels.Users;

namespace TaskManagerMVC.Controllers
{
    public class UserController : BaseController<User, UserIndexVM, UserFilterVM, UserDetailsVM, UserCreateEditVM>
    {
        // Repo
        public override BaseService<User> GetService()
        {
            return new UserService();
        }

        // Index
        public override UserIndexVM PopulateIndexModel(UserIndexVM model)
        {
            model.Filter = new UserFilterVM();
            TryUpdateModel(model);

            BaseService<User> userService = GetService();
            model.Items = userService.GetAll(model.Filter.BuildFilter());

            return model;
        }

        // Details
        public override UserDetailsVM PopulateDetailsModel(UserDetailsVM model)
        {
            BaseService<User> userService = GetService();
            User user = userService.GetByID(model.ID);

            model.Username = user.Username;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.IsAdmin = user.IsAdmin;

            return model;
        }

        // CreateEdit GET
        public override UserCreateEditVM PopulateCreateEditModel(UserCreateEditVM model)
        {
            if (model.ID > 0)
            {
                BaseService<User> userService = GetService();
                User user = userService.GetByID(model.ID);

                model.Username = user.Username;
                model.Password = user.Password;
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.IsAdmin = user.IsAdmin; 
            }

            return model;
        }

        // CreateEdit POST
        public override User PopulateEntity(UserCreateEditVM model, User user)
        {
            user.ID = model.ID;
            user.Username = model.Username;
            user.Password = model.Password;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.IsAdmin = model.IsAdmin;

            return user;
        }
    }
}