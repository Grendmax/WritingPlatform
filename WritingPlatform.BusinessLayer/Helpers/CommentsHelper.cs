using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingPlatform.BusinessLayer.BInterfaces;
using WritingPlatform.BusinessLayer.BusinessObjects;
using WritingPlatform.DataLayer.Entities;
using WritingPlatform.DataLayer.UnitOfWork;

namespace WritingPlatform.BusinessLayer.Helpers
{
    public class CommentsHelper: IComments
    {
        IUnitOfWork Database { get; set; }
        public CommentsHelper(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void Create(CommentsBO comment)
        {
            Comments newComment = new Comments() { Comment = comment.Comment, UserId = comment.UserId,WorkId=comment.WorkId };
            Database.CommentsUowRepository.Create(newComment);
            Database.Save();
        }

        public void DeleteComment(int id)
        {
            Database.CommentsUowRepository.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public CommentsBO GetComment(int id)
        {
            if (id != 0)
            {
                return AutoMapper<Comments, CommentsBO>.Map(Database.CommentsUowRepository.Get, id);
            }
            return new CommentsBO();
        }

        public IEnumerable<CommentsBO> GetComments()
        {
            return AutoMapper<IEnumerable<Comments>, List<CommentsBO>>.Map(Database.CommentsUowRepository.GetAll());
        }

        public void Update(CommentsBO comment)
        {
            Comments newComment = AutoMapper<CommentsBO, Comments>.Map(comment);
            Database.CommentsUowRepository.Update(newComment);
            Database.Save();
        }

    }
}
