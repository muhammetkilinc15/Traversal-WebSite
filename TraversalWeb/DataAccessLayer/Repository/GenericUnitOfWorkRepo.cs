using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericUnitOfWorkRepo<T> : IGenericUnitOfWorkDal<T> where T : class
    {
        private readonly Context _context;

        public GenericUnitOfWorkRepo(Context context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
          _context.Add(entity);
            
        }

        public void MultiUpdate(List<T> entities)
        {
            _context.UpdateRange(entities);
        }

        public void Update(T entity)
        {
           _context.Update(entity);
        }
    }
}
