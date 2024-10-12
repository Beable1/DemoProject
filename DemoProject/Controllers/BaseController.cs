using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DemoProject.Controllers
{
    public class BaseController : Controller
    {
        protected Writer CurrentUser;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            CurrentUser = HttpContext.Items["CurrentUser"] as Writer;
            base.OnActionExecuting(context);
        }
    }
}
