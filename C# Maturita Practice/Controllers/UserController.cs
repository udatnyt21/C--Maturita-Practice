using Microsoft.AspNetCore.Mvc;
using C__Maturita_Practice.Models;
using C__Maturita_Practice.Data;
using BCrypt.Net;

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


            User user = new User() { Name = Name, Password = BCrypt.Net.BCrypt.HashPassword(Password, BCrypt.Net.BCrypt.GenerateSalt())};
            database.Users.Add(user);
            database.SaveChanges();

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
            Name = Name.Trim();
            Password = Password.Trim();

            if (Name == null || Password == null)
                return RedirectToAction("Login");


            User? UserToCheck = database.Users.Where(user => user.Name == Name).FirstOrDefault();

            if (!BCrypt.Net.BCrypt.Verify(Password, UserToCheck.Password))
                return RedirectToAction("Login");

            HttpContext.Session.SetString("LoggedUserName", UserToCheck.Name);

            ViewData["Title"] = "Login";
            return RedirectToAction("Profile");
        }
        [HttpGet]
        public IActionResult Profile()
        {
            ViewData["LoggedUser"] = HttpContext.Session.GetString("LoggedUserName");

            return View();
        }


    }
}
