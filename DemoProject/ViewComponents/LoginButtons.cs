using Microsoft.AspNetCore.Mvc;

namespace DemoProject.ViewComponents
{
    public class LoginButtons: BaseComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var CurrentUser = GetCurrentUser();
            ViewBag.CurrentUser = CurrentUser;

            return View();
        }

    }
}
