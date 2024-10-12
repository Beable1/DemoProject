using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.ViewComponents
{
    public class PostComment:ViewComponent
    {

        
        public IViewComponentResult Invoke()
        {
            

            return View();
        }

    }
}
