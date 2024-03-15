using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IContactUsService:IGenericService<ContactUs>
	{
		public List<ContactUs> TGetListByActive();
		public List<ContactUs> TGetListByFalse();
		void TContacUsChangeStatus(int id);
	}
}
