using DataAccess.Entities;
using ServiceLayer.Services;
using TaskManagerApiWCF.Models;

namespace TaskManagerApiWCF.WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CommentServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CommentServices.svc or CommentServices.svc.cs at the Solution Explorer and start debugging.
    public class CommentServices : BaseServices<Comment, CommentModel>
    {
        public override BaseService<Comment> CreateService()
        {
            return new CommentService();
        }

        public override Comment PopulateEntity(CommentModel model)
        {
            return new Comment()
            {
                ID = model.ID,
                Text = model.Text,
                CreateDate = model.CreateDate,
                TaskID = model.TaskID,
                UserID = model.UserID
            };
        }

        public override CommentModel PopulateModel(Comment comment)
        {
            return new CommentModel()
            {
                ID = comment.ID,
                Text = comment.Text,
                CreateDate = comment.CreateDate,
                TaskID = comment.TaskID,
                UserID = comment.UserID
            };
        }
    }
}