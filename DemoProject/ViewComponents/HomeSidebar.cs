using Microsoft.AspNetCore.Mvc;

namespace DemoProject.ViewComponents
{
    public class HomeSidebar:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
