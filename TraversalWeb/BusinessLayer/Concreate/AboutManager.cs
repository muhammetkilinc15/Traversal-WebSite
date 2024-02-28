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
    public class AboutManager : IAboutService
    {
        private IAboutDal _aboutdal;

        public AboutManager(IAboutDal aboutdal)
        {
            _aboutdal = aboutdal;
        }

        public void TAdd(About entity)
        {
            _aboutdal.Add(entity);
        }

        public About TGetByID(int id)
        {
          return _aboutdal.GetByID(id);
        }

        public List<About> TGetList()
        {
            return _aboutdal.GetAll();
        }

       
        public void TRemove(About entity)
        {
           _aboutdal.Delete(entity);
        }

        public void TUpdate(About entity)
        {
           _aboutdal.Update(entity);
        }
    }
}
