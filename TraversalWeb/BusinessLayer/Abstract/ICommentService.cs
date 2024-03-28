using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ICommentService:IGenericService<Comment>
	{
		List<Comment> TGetListByDestination(int id);
		List<Comment> TGetListWithByDestination();
		List<Comment> TGetListWithByDestinationAndUser(int id);
	}
}
