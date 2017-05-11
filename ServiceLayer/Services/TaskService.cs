using DataAccess.Entities;
using DataAccess.Repositories;

namespace ServiceLayer.Services
{
    public class TaskService : BaseService<Task>
    {
        private TaskRepository Repository { get; set; }

        public override BaseRepository<Task> CreateRepo()
        {
            return new TaskRepository();
        }

        public TaskService()
        {
            Repository = new TaskRepository();
        }
    }
}