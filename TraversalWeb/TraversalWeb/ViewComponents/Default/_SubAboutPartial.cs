using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalWeb.ViewComponents.Default
{
    public class _SubAboutPartial:ViewComponent
    {
        private SubAboutManager subAboutManager = new SubAboutManager(new EfSubAboutDal());
        public IViewComponentResult Invoke()
        {
            var values = subAboutManager.TGetList();
            return View(values);
        }
    }
}
