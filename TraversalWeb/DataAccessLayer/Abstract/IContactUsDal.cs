using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IContactUsDal:IGenericDal<ContactUs>
	{
		public List<ContactUs> GetListByActive();
		public List<ContactUs> TGetListByFalse();
		void ContacUsChangeStatus(int id);
	}
}
