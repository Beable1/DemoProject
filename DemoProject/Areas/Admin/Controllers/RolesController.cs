
using CoreDemo.Areas.Admin.Models;
using DemoProject.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
	{
		private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RolesController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
		{
			var roles = _roleManager.Roles.ToList();
			return View(roles);
		}


		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateRoleViewModel cr)
		{
			AppRole role = new AppRole
			{
				Name = cr.name
			};

			await _roleManager.CreateAsync(role);
			return RedirectToAction("index","Roles");
		}

		public async Task<IActionResult> Delete(int id)
		{
			var role= _roleManager.Roles.FirstOrDefault(y=>y.Id==id);
			await _roleManager.DeleteAsync(role);
            return RedirectToAction("index", "Roles");
        }

		public IActionResult Update(int id)
		{
			var values=_roleManager.Roles.FirstOrDefault(X=>X.Id==id);
			RoleUpdateViewModel role = new RoleUpdateViewModel
			{
				id = values.Id,
				name = values.Name
			};

			return View(role);
		}
		[HttpPost]
        public async Task<IActionResult> Update(RoleUpdateViewModel ur)
        {
            Console.WriteLine("AAAAAAAAAAAAAAAAAAAA");
            Console.WriteLine(ur.name);
            var values = _roleManager.Roles.Where(X => X.Id == ur.id).FirstOrDefault();

			values.Name= ur.name;
			await _roleManager.UpdateAsync(values);


            return RedirectToAction("index", "Roles");
        }



        public IActionResult UserRoleList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();

            TempData["UserId"] = user.Id;
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> model = new List<RoleAssignViewModel>();
            foreach (var item in roles)
            {
                RoleAssignViewModel m = new RoleAssignViewModel();
                m.RoleID = item.Id;
                m.Name = item.Name;
                m.Exists = userRoles.Contains(item.Name);
                model.Add(m);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userId = (int)TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            foreach (var item in model)
            {
                if (item.Exists) //checkbox seçiliyse(durumu trueysa)
                {
                    await _userManager.AddToRoleAsync(user, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);
                }
            }
            return RedirectToAction("UserRoleList");
        }

    }
}
