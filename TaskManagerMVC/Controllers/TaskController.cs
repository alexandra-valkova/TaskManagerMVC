using DataAccess.Entities;
using System;
using TaskManagerMVC.Models;
using TaskManagerMVC.ViewModels.Tasks;
using System.Web.Mvc;
using System.Linq;
using ServiceLayer.Services;

namespace TaskManagerMVC.Controllers
{
    public class TaskController : BaseController<Task, TaskIndexVM, TaskFilterVM, TaskDetailsVM, TaskCreateEditVM>
    {
        // Repo
        public override BaseService<Task> GetService()
        {
            return new TaskService();
        }

        // Index
        public override TaskIndexVM PopulateIndexModel(TaskIndexVM model)
        {
            model.Filter = new TaskFilterVM();
            TryUpdateModel(model);

            BaseService<Task> taskService = GetService();

            model.Items = taskService.GetAll(model.Filter.BuildFilter());

            return model;
        }

        // Details
        public override TaskDetailsVM PopulateDetailsModel(TaskDetailsVM model)
        {
            TryUpdateModel(model);

            BaseService<Task> taskService = GetService();
            UserService userService = new UserService();
            LogworkService logworkService = new LogworkService();
            CommentService commentService = new CommentService();

            Task task = taskService.GetByID(model.ID);

            model.Title = task.Title;
            model.Description = task.Description;
            model.WorkingHours = task.WorkingHours;
            model.Creator = userService.GetByID(task.CreatorID).Username;
            model.Responsible = userService.GetByID(task.ResponsibleID).Username;
            model.CreateDate = task.CreateDate;
            model.LastEditDate = task.LastEditDate;
            model.Status = task.Status;
            model.Logworks = logworkService.GetAll(l => l.TaskID == task.ID);
            model.Comments = commentService.GetAll(c => c.TaskID == task.ID);

            //Pager
            model.LogworksPager = new Pager(model.Logworks.Count, model.LogworksPager == null ? 1 : model.LogworksPager.CurrentPage, "LogworksPager.", "Details", "Task", model.LogworksPager == null ? 3 : model.LogworksPager.PageSize);
            model.Logworks = model.Logworks.Skip((model.LogworksPager.CurrentPage - 1) * model.LogworksPager.PageSize).Take(model.LogworksPager.PageSize).ToList();

            model.CommentsPager = new Pager(model.Comments.Count, model.CommentsPager == null ? 1 : model.CommentsPager.CurrentPage, "CommentsPager.", "Details", "Task", model.CommentsPager == null ? 3 : model.CommentsPager.PageSize);
            model.Comments = model.Comments.Skip((model.CommentsPager.CurrentPage - 1) * model.CommentsPager.PageSize).Take(model.CommentsPager.PageSize).ToList();

            return model;
        }

        // CreateEdit GET
        public override TaskCreateEditVM PopulateCreateEditModel(TaskCreateEditVM model)
        {
            if (model.ID > 0) // Edit
            {
                BaseService<Task> taskService = GetService();
                Task task = taskService.GetByID(model.ID);

                model.Title = task.Title;
                model.Description = task.Description;
                model.WorkingHours = task.WorkingHours;
                model.CreatorID = task.CreatorID;
                model.ResponsibleID = task.ResponsibleID;
                model.CreateDate = task.CreateDate;
                model.LastEditDate = task.LastEditDate;
                model.Status = task.Status;
            }

            return model;
        }

        // CreateEdit POST
        public override Task PopulateEntity(TaskCreateEditVM model, Task task)
        {
            task.ID = model.ID;
            task.Title = model.Title;
            task.Description = model.Description;
            task.WorkingHours = model.WorkingHours;
            task.Status = model.Status;
            task.CreatorID = model.CreatorID;
            task.ResponsibleID = model.ResponsibleID;
            task.CreateDate = model.CreateDate;
            task.LastEditDate = DateTime.Now;

            if (model.ID == 0) // Create
            {
                task.CreateDate = DateTime.Now;
                task.CreatorID = AuthenticationManager.LoggedUser.ID;
            }

            return task;
        }

        // LOGWORKS

        // GET
        public PartialViewResult CreateLogwork(int? id)
        {
            TaskCreateLogworkVM model = new TaskCreateLogworkVM()
            {
                TaskID = id.Value
            };

            return PartialView(model);
        }

        // POST
        [HttpPost]
        public ActionResult CreateLogwork(TaskCreateLogworkVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Logwork logwork = new Logwork()
            {
                TaskID = model.TaskID,
                UserID = AuthenticationManager.LoggedUser.ID,
                WorkingHours = model.WorkingHours,
                CreateDate = DateTime.Now
            };

            LogworkService logworkService = new LogworkService();
            logworkService.Save(logwork);

            return RedirectToAction("Details", new { id = model.TaskID });
        }

        // COMMENTS

        // GET
        public PartialViewResult CreateComment(int? id)
        {
            TaskCreateCommentVM model = new TaskCreateCommentVM()
            {
                TaskID = id.Value
            };

            return PartialView(model);
        }

        // POST
        [HttpPost]
        public ActionResult CreateComment(TaskCreateCommentVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Comment comment = new Comment()
            {
                TaskID = model.TaskID,
                UserID = AuthenticationManager.LoggedUser.ID,
                Text = model.Text,
                CreateDate = DateTime.Now
            };

            CommentService commentService = new CommentService();
            commentService.Save(comment);

            return RedirectToAction("Details", new { id = model.TaskID });
        }
    }
}