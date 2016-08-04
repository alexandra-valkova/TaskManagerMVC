using DataAccess.Entities;
using System.ComponentModel.DataAnnotations;
using TaskManagerMVC.Attributes;

namespace TaskManagerMVC.ViewModels.Users
{
    public class UserCreateEditVM : BaseCreateEditVM<User>
    {
        [Required]
        [DataType(DataType.Text)]
        [Unique("DataAccess.Entities.User", "DataAccess.Repositories.UserRepository")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Admin")]
        public bool IsAdmin { get; set; }
    }
}