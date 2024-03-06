using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IReservationService:IGenericService<Reservation>
    {
        List<Reservation> TGetListApproval(int userId);
        List<Reservation> TGetListCurrent(int userId);
        List<Reservation> TGetListPrevious(int userId);
    }
}
