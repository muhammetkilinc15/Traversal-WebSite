using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.AbstractUnitOfWork
{
    public interface IGenericUnitOfWorkService<T>
    {
        void TAdd(T entity);
        void TUpdate(T entity);
        void TMultiUpdate(List<T> entities);
        T TGetByID(int id); 
    }

}
