using Journals_System.Models;
using Journals_System.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Journals_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly IResearchersServices _researchersServices;

        public HomeController(IResearchersServices researchersServices)
        {
            _researchersServices = researchersServices;
        }

        public IActionResult Index()
        {
            ViewData["Login"] = true;
            return View();
        }

        public IActionResult MyJournals(string? emailLog, string? passwordLog)
        {

            return View();
        }

        public IActionResult Researchers()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public async Task<IActionResult> Login(string? emailLog, string? passwordLog)
        {

            return RedirectToAction("MyJournals");
        }
    }
}
