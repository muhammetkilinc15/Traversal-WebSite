using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private Context _context = new Context();
        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {

            _context.Remove(entity);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByID(int id)
        {

            return _context.Set<T>().Find(id);
        }

        public List<T> GetListByFilter(Expression<Func<T, bool>> filter)
        {

           return _context.Set<T>().Where(filter).ToList();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
