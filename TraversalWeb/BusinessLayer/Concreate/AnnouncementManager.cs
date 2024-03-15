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
	public class AnnouncementManager : IAnnouncementService
	{
		private readonly IAnnouncementDal announcementDal;
		public AnnouncementManager(IAnnouncementDal announcementDal)
		{
			this.announcementDal = announcementDal;
		}

		public void TAdd(Announcement entity)
		{
			announcementDal.Add(entity);
		}

		public Announcement TGetByID(int id)
		{
			return announcementDal.GetByID(id);
		}

		public List<Announcement> TGetList()
		{
			return announcementDal.GetAll();
		}

		public void TRemove(Announcement entity)
		{
			announcementDal.Delete(entity);
		}

		public void TUpdate(Announcement entity)
		{
			announcementDal.Update(entity);
		}
	}
}
