using DataAccess.Entities;
using DataAccess.Repositories;
using TaskManagerMVC.ViewModels.Users;

namespace TaskManagerMVC.Controllers
{
    public class UserController : BaseController<User, UserIndexVM, UserFilterVM, UserDetailsVM, UserCreateEditVM>
    {
        // Repo
        public override BaseRepository<User> GetRepo()
        {
            return new UserRepository();
        }

        // Index
        public override UserIndexVM PopulateIndexModel(UserIndexVM model)
        {
            model.Filter = new UserFilterVM();
            TryUpdateModel(model);

            BaseRepository<User> userRepo = GetRepo();
            model.Items = userRepo.GetAll(model.Filter.BuildFilter());

            return model;
        }

        // Details
        public override UserDetailsVM PopulateDetailsModel(UserDetailsVM model)
        {
            BaseRepository<User> userRepo = GetRepo();
            User user = userRepo.GetByID(model.ID);

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
                BaseRepository<User> userRepo = GetRepo();
                User user = userRepo.GetByID(model.ID);

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