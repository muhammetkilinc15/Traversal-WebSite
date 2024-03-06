using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repository;
using EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
      

        public List<Reservation> GetListReservationWithStatus(int userId, int statusId)
        {
            using (var c = new Context())
            {
                return c.Reservations.Include(x => x.Status).Include(x=>x.Destination).Where(x => x.ReservationStatusID == statusId && x.AppUserID==userId).ToList();
            }
        }
    }
}
