using DataAccess.Entities;
using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using TaskManagerMVC.Attributes;
using TaskManagerMVC.Models;

namespace TaskManagerMVC.ViewModels.Tasks
{
    public class TaskFilterVM : BaseFilterVM<Task>
    {
        [FilterProperty(DisplayName = "Title")]
        public string Title { get; set; }

        [FilterProperty(DisplayName = "Description")]
        public string Description { get; set; }

        [FilterProperty(DisplayName = "Status", DropDownList = "StatusList")]
        public StatusEnum? Status { get; set; }

        public SelectList StatusList
        {
            get
            {
                return new SelectList(new[]
                {
                    new { Value = "", Text = "All tasks" },
                    new { Value = StatusEnum.Done.ToString(), Text = "Done" },
                    new { Value = StatusEnum.Pending.ToString(), Text = "Pending" },
                }, "Value", "Text", Status);
            }
        }

        public override Expression<Func<Task, bool>> BuildFilter()
        {
            return t => (string.IsNullOrEmpty(Title) || t.Title.Contains(Title))
                     && (string.IsNullOrEmpty(Description) || t.Description.Contains(Description))
                     && (Status == null || t.Status == Status)
                     && (t.CreatorID == AuthenticationManager.LoggedUser.ID || t.ResponsibleID == AuthenticationManager.LoggedUser.ID);
        }
    }
}