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
    public class EfGuideDal : GenericRepository<Guide>, IGuideDal
    {
        public void ChangeStatus(int id)
        {
            using (var c = new Context())
            {
                Guide guide = c.Guides.Find(id);
                if (guide.Status)
                {
                    guide.Status = false;
                }
                else
                {
                    guide.Status = true;
                }
                c.Update(guide);
                c.SaveChanges();
            }
        }
    }
}
