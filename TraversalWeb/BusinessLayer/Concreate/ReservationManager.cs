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
    public class ReservationManager : IReservationService
    {
        private IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public void TAdd(Reservation entity)
        {
            _reservationDal.Add(entity);
        }

        public Reservation TGetByID(int id)
        {
            return _reservationDal.GetByID(id);
        }

        public List<Reservation> TGetList()
        {
          return _reservationDal.GetAll();
        }

      

        public List<Reservation> TGetListApproval(int userId)
        {
            return _reservationDal.GetListReservationWithStatus(userId, 1);
        }

        public List<Reservation> TGetListCurrent(int userId)
        {
            return _reservationDal.GetListReservationWithStatus(userId,3);
        }

        public List<Reservation> TGetListPrevious(int userId)
        {

            return _reservationDal.GetListReservationWithStatus(userId, 2);
        }

        public void TRemove(Reservation entity)
        {
            _reservationDal.Delete(entity);
        }

        public void TUpdate(Reservation entity)
        {
            _reservationDal.Update(entity);
        }
    }
}
