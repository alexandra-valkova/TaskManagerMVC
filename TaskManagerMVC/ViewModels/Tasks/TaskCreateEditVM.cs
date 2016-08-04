using DataAccess.Entities;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TaskManagerMVC.ViewModels.Tasks
{
    public class TaskCreateEditVM : BaseCreateEditVM<Task>
    {
        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Working Hours")]
        [Range(1, int.MaxValue, ErrorMessage = "Plese enter a valid integer!")]
        public int WorkingHours { get; set; }

        public int CreatorID { get; set; }

        [Display(Name = "Responsible")]
        public int ResponsibleID { get; set; }

        public List<SelectListItem> UsersList
        {
            get
            {
                UserRepository userRepo = new UserRepository();
                List<User> usersAll = userRepo.GetAll();
                List<SelectListItem> users = new List<SelectListItem>();
                foreach (User user in usersAll)
                {
                    users.Add(new SelectListItem { Text = user.Username, Value = user.ID.ToString(), Selected = ResponsibleID == user.ID });
                }
                return users;
            }
        }

        public DateTime CreateDate { get; set; }

        public DateTime LastEditDate { get; set; }

        [Required]
        [EnumDataType(typeof(StatusEnum))]
        public StatusEnum Status { get; set; }
    }
}