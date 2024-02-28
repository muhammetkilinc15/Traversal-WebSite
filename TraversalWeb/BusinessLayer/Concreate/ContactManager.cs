using BusinessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    internal class ContactManager : IContactService
    {
        public void TAdd(Contact entity)
        {
            throw new NotImplementedException();
        }

        public Contact TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TRemove(Contact entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Contact entity)
        {
            throw new NotImplementedException();
        }
    }
}
