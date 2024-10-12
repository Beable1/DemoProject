using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
   
    public class ErrorPageController : Controller
    {
        
        public IActionResult Error1(int code)
        {
            return View();
        }
    }
}
