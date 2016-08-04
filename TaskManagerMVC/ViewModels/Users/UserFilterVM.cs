using DataAccess.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TaskManagerMVC.ViewModels.Users
{
    public class UserFilterVM : BaseFilterVM<User>
    {
        public string Username { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public override Expression<Func<User, bool>> BuildFilter()
        {
            return u => (string.IsNullOrEmpty(Username) || u.Username.Contains(Username))
                     && (string.IsNullOrEmpty(FirstName) || u.FirstName.Contains(FirstName))
                     && (string.IsNullOrEmpty(LastName) || u.LastName.Contains(LastName));
        }
    }
}