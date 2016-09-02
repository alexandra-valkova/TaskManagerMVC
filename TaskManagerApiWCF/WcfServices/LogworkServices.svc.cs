using DataAccess.Entities;
using ServiceLayer.Services;
using TaskManagerApiWCF.Models;

namespace TaskManagerApiWCF.WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LogworkServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LogworkServices.svc or LogworkServices.svc.cs at the Solution Explorer and start debugging.
    public class LogworkServices : BaseServices<Logwork, LogworkModel>
    {
        public override BaseService<Logwork> CreateService()
        {
            return new LogworkService();
        }

        public override Logwork PopulateEntity(LogworkModel model)
        {
            return new Logwork()
            {
                ID = model.ID,
                WorkingHours = model.WorkingHours,
                CreateDate = model.CreateDate,
                TaskID = model.TaskID,
                UserID = model.UserID
            };
        }

        public override LogworkModel PopulateModel(Logwork logwork)
        {
            return new LogworkModel()
            {
                ID = logwork.ID,
                WorkingHours = logwork.WorkingHours,
                CreateDate = logwork.CreateDate,
                TaskID = logwork.TaskID,
                UserID = logwork.UserID
            };
        }
    }
}