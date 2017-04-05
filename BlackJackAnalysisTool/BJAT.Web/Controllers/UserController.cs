using System.Web.Mvc;
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
        public ActionResult Register(UserModel user)
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserModel user)
        {
            return View();
        }

        public ActionResult LogOut()
        {
            return View();
        }
    }
}