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
            
        }
        [HttpPost]
        public IActionResult Register(string Name, string Password, string PasswordCheck , bool AIConsent)
        {

        }

        [HttpGet]
        public IActionResult Login()
        {

        }
        [HttpPost]
        public IActionResult Login(string Name, string Password)
        {

        }


    }
}
