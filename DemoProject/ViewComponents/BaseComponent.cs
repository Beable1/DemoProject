using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DemoProject.ViewComponents
{
    public abstract class BaseComponent : ViewComponent
    {
        protected Writer CurrentUser;

        public BaseComponent()
        {
            // This will be null until the first request is made, use a method instead
        }

        protected Writer GetCurrentUser()
        {
            // Safely access HttpContext and retrieve the current user
            return HttpContext?.Items["CurrentUser"] as Writer;
        }
    }
}
