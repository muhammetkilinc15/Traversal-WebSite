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
	public class ContactUsManager : IContactUsService
	{
		IContactUsDal contactUsDal;

		public ContactUsManager(IContactUsDal contactUsDal)
		{
			this.contactUsDal = contactUsDal;
		}

		public void TAdd(ContactUs entity)
		{
			contactUsDal.Add(entity);
		}

		public void TContacUsChangeStatus(int id)
		{
			contactUsDal.ContacUsChangeStatus(id);
		}

		public ContactUs TGetByID(int id)
		{
			return contactUsDal.GetByID(id);
		}

		public List<ContactUs> TGetList()
		{
			return contactUsDal.GetAll();
		}

		public List<ContactUs> TGetListByActive()
		{
			return contactUsDal.GetListByActive();
		}

		public List<ContactUs> TGetListByFalse()
		{
			return contactUsDal.TGetListByFalse();
		}

		public void TRemove(ContactUs entity)
		{
			contactUsDal.Delete(entity);
		}

		public void TUpdate(ContactUs entity)
		{
			contactUsDal.Update(entity);
		}
	}
}
