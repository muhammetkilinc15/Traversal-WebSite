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
    public class FeatureManager : IFeatureService
    {
        private IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public void TAdd(Feature entity)
        {
            _featureDal.Add(entity);
        }

        public Feature TGetByID(int id)
        {
           return _featureDal.GetByID(id);
        }

        public List<Feature> TGetList()
        {
          return _featureDal.GetAll();
        }

        public void TRemove(Feature entity)
        {
            _featureDal.Delete(entity);
        }

        public void TUpdate(Feature entity)
        {
            _featureDal.Update(entity);
        }
    }
}
