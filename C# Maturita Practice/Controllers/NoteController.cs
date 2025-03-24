using Microsoft.AspNetCore.Mvc;
using C__Maturita_Practice.Models;
using C__Maturita_Practice.Data;

namespace C__Maturita_Practice.Controllers
{
    public class NoteController : Controller
    {
        MyDBContext database;

        public NoteController(MyDBContext context)
        {
            database = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(String Title, String Text, String IsImportant)
        {
            Title = Title.Trim();
            Text = Text.Trim();
            IsImportant = IsImportant.Trim();
            int? Owner = HttpContext.Session.GetInt32("LoggedID");
            DateTime date = DateTime.Now;
            bool important;
            if (IsImportant == "on") important = true; else important = false;

            if (Title == null || Text == null)
                return RedirectToAction("Create");

            Note toBeAdded = new Note() {Owner = Owner.Value, Title = Title, Text = Text, Date = date, Important = important };

            database.Notes.Add(toBeAdded);
            database.SaveChanges();

            return RedirectToAction("Profile", "User");
        }
        [HttpPost]
        public IActionResult Delete()
        {
            return RedirectToAction("Profile", "User");
        }
        [HttpPost]
        public IActionResult SetImportant()
        {
            return RedirectToAction("Profile", "User");
        }
    }
}
