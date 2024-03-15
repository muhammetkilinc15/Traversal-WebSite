using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repository;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfContactUsDal : GenericRepository<ContactUs>, IContactUsDal
	{
		public void ContacUsChangeStatus(int id)
		{
			using (var c = new Context())
			{
				var value = c.ContactUses.Find(id);
				value.Status = value.Status == true ? false : true;
				c.Update(value);
				c.SaveChanges();
			}
		}

		public List<ContactUs> GetListByActive()
		{
			using (var c = new Context())
			{
				return c.ContactUses.Where(x => x.Status == true).ToList();
			}
		}

		public List<ContactUs> TGetListByFalse()
		{
			using (var c = new Context())
			{
				return c.ContactUses.Where(x => x.Status == false).ToList();
			}
		}
	}
}
