using Journals_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Journals_System.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
