using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
	public class CommentManager : ICommentService
	{
		private ICommentDal _commentDal;

		public CommentManager(ICommentDal commentDal)
		{
			_commentDal = commentDal;
		}

		public void TAdd(Comment entity)
		{
			_commentDal.Add(entity);
		}

		public Comment TGetByID(int id)
		{
			return _commentDal.GetByID(id);
		}

		public List<Comment> TGetList()
		{
			return _commentDal.GetAll();
		}

        public List<Comment> TGetListByDestination(int id)
        {
			return _commentDal.GetListByFilter(x=>x.DestinationID==id);
        }

        public void TRemove(Comment entity)
		{
			_commentDal.Delete(entity);
		}

		public void TUpdate(Comment entity)
		{
			_commentDal.Update(entity);
		}
	}
}
