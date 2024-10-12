using AutoMapper;
using BusinessLayer.Abstract;
using DemoProject.Models;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DemoProject.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IMapper _mapper;
        public UserController( IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
           
            _mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserSignUpDto u)
        {
           if(ModelState.IsValid){

                
     

                AppUser user = new AppUser()
                {
                    Email = u.Mail,
                    UserName = u.UserName,
                    NameSurname = u.NameSurname,
                };

                var result = await userManager.CreateAsync(user, u.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("login", "user");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                       
                    }
                }

            }

       

            return View(u);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserSignInViewModel s)
        {
            
          

            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(s.username, s.password, true, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("details", "profile");
                }
                else
                {
                    return View();
                }


            }

                return View();
        }

        public async Task<IActionResult> Logout()
        {

            await signInManager.SignOutAsync();
            return RedirectToAction("login", "user");
        }


        public async Task<IActionResult> AccessDenied()
        {

            return View();
        }

    }
}
