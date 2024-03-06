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
    public class GuideManager : IGuideService
    {
        private readonly IGuideDal guideDal;

        public GuideManager(IGuideDal guideDal)
        {
            this.guideDal = guideDal;
        }

        public void TAdd(Guide entity)
        {
            guideDal.Add(entity);
        }

        public Guide TGetByID(int id)
        {
            return guideDal.GetByID(id);
        }

        public List<Guide> TGetList()
        {
            return guideDal.GetAll();
        }

        public void TRemove(Guide entity)
        {
            guideDal.Delete(entity);
        }

        public void TUpdate(Guide entity)
        {
            guideDal.Update(entity);
        }
    }
}
