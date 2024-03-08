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
	public class AppUserManager : IAppUserService
	{
		private IAppUserDal appuserDal;

		public AppUserManager(IAppUserDal appuserDal)
		{
			this.appuserDal = appuserDal;
		}

		public void TAdd(AppUser entity)
		{
			appuserDal.Add(entity);
		}

		public AppUser TGetByID(int id)
		{
			return appuserDal.GetByID(id);
		}

		public List<AppUser> TGetList()
		{
			return appuserDal.GetAll();
		}

		public void TRemove(AppUser entity)
		{
			appuserDal.Delete(entity);
		}

		public void TUpdate(AppUser entity)
		{
			appuserDal.Update(entity);
		}
	}
}
