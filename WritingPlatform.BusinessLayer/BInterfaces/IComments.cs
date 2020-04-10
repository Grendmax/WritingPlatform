using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingPlatform.BusinessLayer.BusinessObjects;

namespace WritingPlatform.BusinessLayer.BInterfaces
{
    public interface IComments
    {
        void Create(CommentsBO comment);
        void Update(CommentsBO comment);
        CommentsBO GetComment(int id);
        IEnumerable<CommentsBO> GetComments();
        void DeleteComment(int id);
        void Dispose();
    }
}
