using DataAccess.Entities;
using System;
using System.Linq.Expressions;
using TaskManagerMVC.Models;

namespace TaskManagerMVC.ViewModels.Tasks
{
    public class TaskFilterVM : BaseFilterVM<Task>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public override Expression<Func<Task, bool>> BuildFilter()
        {
            return t => (string.IsNullOrEmpty(Title) || t.Title.Contains(Title))
                     && (string.IsNullOrEmpty(Description) || t.Description.Contains(Description))
                     && (t.CreatorID == AuthenticationManager.LoggedUser.ID || t.ResponsibleID == AuthenticationManager.LoggedUser.ID);
        }
    }
}