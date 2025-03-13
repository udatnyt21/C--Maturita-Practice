using Microsoft.AspNetCore.Mvc;
using C__Maturita_Practice.Models;
using C__Maturita_Practice.Data;

namespace C__Maturita_Practice.Controllers
{
    public class UserController : Controller
    {
        MyDBContext database;

        public UserController(MyDBContext context)
        {
            database = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewData["Title"] = "Register";
            return View();
        }
        [HttpPost]
        public IActionResult Register(string Name, string Password, string PasswordCheck, string AIConsent)
        {
            Name = Name.Trim();
            Password = Password.Trim();
            PasswordCheck = PasswordCheck.Trim();

            if (AIConsent != "on")
                return RedirectToAction("Register");
            if (Name == null || Password == null || PasswordCheck == null || Password != PasswordCheck)
                return RedirectToAction("Register");

            User? existingUser = database.Users.Where(user => user.Name == Name).FirstOrDefault();

            if (existingUser != null)
                return RedirectToAction("Register");

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewData["Title"] = "Login";
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Name, string Password)
        {
            return RedirectToAction("Profile");
        }


    }
}
