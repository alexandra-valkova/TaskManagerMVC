using DataAccess.Entities;
using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using TaskManagerMVC.Attributes;

namespace TaskManagerMVC.ViewModels.Users
{
    public class UserFilterVM : BaseFilterVM<User>
    {
        [FilterProperty(DisplayName = "Username")]
        public string Username { get; set; }
        
        [FilterProperty(DisplayName = "First Name")]
        public string FirstName { get; set; }
        
        [FilterProperty(DisplayName = "Last Name")]
        public string LastName { get; set; }
        
        [FilterProperty(DisplayName = "Admin", DropDownList = "AdminList")]
        public bool? IsAdmin { get; set; }

        public SelectList AdminList
        {
            get
            {
                return new SelectList(new[]
                {
                    new { Value = "", Text = "All users" },
                    new { Value = "true", Text = "Only admins" },
                    new { Value = "false", Text = "Only non admins" },
                }, "Value", "Text", IsAdmin);
            }
        }

        public override Expression<Func<User, bool>> BuildFilter()
        {
            return u => (string.IsNullOrEmpty(Username) || u.Username.Contains(Username))
                     && (string.IsNullOrEmpty(FirstName) || u.FirstName.Contains(FirstName))
                     && (string.IsNullOrEmpty(LastName) || u.LastName.Contains(LastName))
                     && (IsAdmin == null || u.IsAdmin == IsAdmin);
        }
    }
}