using BusinessLayer.Abstract.AbstractUnitOfWork;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate.UnitOfWorkConcreate
{
    public class AccountManager : IAccountService
    {
        private readonly IAccountDal accountDal;
        private readonly IUnitOfWorkDal unitOfWorkDal;

        public AccountManager(IAccountDal accountDal, IUnitOfWorkDal unitOfWorkDal)
        {
            this.accountDal = accountDal;
            this.unitOfWorkDal = unitOfWorkDal;
        }

        public void TAdd(Account entity)
        {
           accountDal.Add(entity);
            unitOfWorkDal.Save();
        }

        public Account TGetByID(int id)
        {
           return accountDal.GetById(id);
            
        }

        public void TMultiUpdate(List<Account> entities)
        {
            accountDal.MultiUpdate(entities);
            unitOfWorkDal.Save();
        }

        public void TUpdate(Account entity)
        {
           accountDal.Update(entity);
            unitOfWorkDal.Save();
        }
    }
}
