using BusinessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    internal class NewsletterManager : INewsletterService
    {
        public void Add(Newsletter entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Newsletter entity)
        {
            throw new NotImplementedException();
        }

        public List<Newsletter> GetAll()
        {
            throw new NotImplementedException();
        }

        public Newsletter GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Newsletter> GetListByFilter(Expression<Func<Newsletter, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Newsletter entity)
        {
            throw new NotImplementedException();
        }
    }
}
