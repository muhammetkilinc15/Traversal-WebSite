using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repository;
using EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfCommentDal : GenericRepository<Comment>, ICommentDal
	{
		public List<Comment> TGetListWİthDestination()
		{
			using(var c = new Context())
			{
				return c.Comments.Include(x => x.Destination).ToList();
			}
			
		}

		public List<Comment> TGetListWİthDestinationAndUser(int id)
		{
			using (var c = new Context())
			{
				return c.Comments.Where(x=>x.DestinationID==id).Include(x=>x.AppUser).ToList();
			}
		}
	}
}
