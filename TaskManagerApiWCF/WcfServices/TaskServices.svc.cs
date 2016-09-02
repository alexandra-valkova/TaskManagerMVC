using DataAccess.Entities;
using ServiceLayer.Services;
using TaskManagerApiWCF.Models;

namespace TaskManagerApiWCF.WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TaskServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TaskServices.svc or TaskServices.svc.cs at the Solution Explorer and start debugging.
    public class TaskServices : BaseServices<Task, TaskModel>
    {
        public override BaseService<Task> CreateService()
        {
            return new TaskService();
        }

        public override Task PopulateEntity(TaskModel model)
        {
            return new Task()
            {
                ID = model.ID,
                Title = model.Title,
                Description = model.Description,
                WorkingHours = model.WorkingHours,
                CreateDate = model.CreateDate,
                LastEditDate = model.LastEditDate,
                Status = (DataAccess.Entities.StatusEnum)model.Status,
                CreatorID = model.CreatorID,
                ResponsibleID = model.ResponsibleID
            };
        }

        public override TaskModel PopulateModel(Task task)
        {
            return new TaskModel()
            {
                ID = task.ID,
                Title = task.Title,
                Description = task.Description,
                WorkingHours = task.WorkingHours,
                CreateDate = task.CreateDate,
                LastEditDate = task.LastEditDate,
                Status = (Models.StatusEnum)task.Status,
                CreatorID = task.CreatorID,
                ResponsibleID = task.ResponsibleID
            };
        }
    }
}