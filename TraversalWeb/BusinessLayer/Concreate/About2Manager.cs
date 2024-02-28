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
    public class About2Manager : IAbout2Service
    {
        private IAbout2Dal _about2Dal;

        public About2Manager(IAbout2Dal about2Dal)
        {
            _about2Dal = about2Dal;
        }

        public void TAdd(About2 entity)
        {
            _about2Dal.Add(entity);
        }

        public About2 TGetByID(int id)
        {
          return  _about2Dal.GetByID(id);
        }

        public List<About2> TGetList()
        {
           return _about2Dal.GetAll();
        }

        public void TRemove(About2 entity)
        {
            _about2Dal.Delete(entity);
        }

        public void TUpdate(About2 entity)
        {
            _about2Dal.Update(entity);
        }
    }
}
