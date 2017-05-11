using DataAccess.Entities;
using DataAccess.Repositories;

namespace ServiceLayer.Services
{
    public class CommentService : BaseService<Comment>
    {
        private CommentRepository Repository { get; set; }

        public override BaseRepository<Comment> CreateRepo()
        {
            return new CommentRepository();
        }

        public CommentService()
        {
            Repository = new CommentRepository();
        }
    }
}