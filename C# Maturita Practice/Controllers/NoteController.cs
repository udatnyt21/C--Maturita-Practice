using Microsoft.AspNetCore.Mvc;

namespace C__Maturita_Practice.Controllers
{
    public class NoteController : Controller
    {
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
        public IActionResult Create(String Title, String Text, String isImportant)
        {
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
