using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalWeb.ViewComponents.Default
{
    public class _PopularDestinationsPartial:ViewComponent
    {
       private DestinationManager destinationManager= new DestinationManager(new EfDestinationDal());
        public IViewComponentResult Invoke()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }
    }
}
