using DataAccess.Entities;

namespace ServiceLayer.Services
{
    public class AuthenticationService
    {
        public User LoggedUser { get; set; }

        public void AuthenticateUser(string username, string password)
        {
            UserService userService = new UserService();

            LoggedUser = userService.GetFirst(u => u.Username == username && u.Password == password);
        }
    }
}
