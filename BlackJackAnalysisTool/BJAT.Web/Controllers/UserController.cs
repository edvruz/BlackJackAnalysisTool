using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using BJAT.Data.Entities;
using BJAT.Services.Contracts;
using BJAT.Web.Models;

namespace BJAT.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }






        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegisterModel user)
        {
            if (ModelState.IsValid)
            {
                var userEntity = Mapper.Map<User>(user);
                if (_userService.RegisterUser(userEntity))
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Data is not correct");

            return View(user);
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserLoginModel user)
        {
            if (!ModelState.IsValid) return View(user);

            if (_userService.IsUserCredentialsValid(user.UserNameOrEmail, user.Password))
            {
                FormsAuthentication.SetAuthCookie(user.UserNameOrEmail, false);
                _userService.LoginSuccesfull(user.UserNameOrEmail);
                return RedirectToAction("Index", "Home");
            }

            _userService.FailedToLogin(user.UserNameOrEmail);

            ModelState.AddModelError("", "User credentials are incorrect");

            return View(user);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}