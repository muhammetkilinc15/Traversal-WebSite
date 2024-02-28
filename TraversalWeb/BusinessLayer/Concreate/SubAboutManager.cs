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
    public class SubAboutManager : ISubAboutService
    {
        private ISubAboutDal _subAboutDal;

        public SubAboutManager(ISubAboutDal subAboutDal)
        {
            _subAboutDal = subAboutDal;
        }

        public void TAdd(SubAbout entity)
        {
            _subAboutDal.Add(entity);
        }

        public SubAbout TGetByID(int id)
        {
           return  _subAboutDal.GetByID(id);
        }

        public List<SubAbout> TGetList()
        {
            return _subAboutDal.GetAll();
        }

        public void TRemove(SubAbout entity)
        {
            _subAboutDal.Delete(entity);
        }

        public void TUpdate(SubAbout entity)
        {
            _subAboutDal.Update(entity);
        }
    }
}
