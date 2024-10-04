using Journals_System.Models;
using Journals_System.Models.Database;
using Journals_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace Journals_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly dbContext _dbContext;
        private readonly IResearchersServices _researchersServices;

        public HomeController(dbContext dbContext,IResearchersServices researchersServices)
        {
            _dbContext = dbContext;
            _researchersServices = researchersServices;
        }

        //<Summary>
        //Main View
        //<Summary>
        public IActionResult Index()
        {
            ViewData["Login"] = true;
            return View();
        }

        //<Summary>
        //Method that obtains researcher in session journals
        //<Summary>
        public IActionResult MyJournals(string? emailLog, string? passwordLog)
        {

            return View();
        }
        //<Summary>
        //Method to get researchers from database
        //to visualize it in view
        //<Summary>
        public IActionResult Researchers()
        {
            return View();
        }

        //<Summary>
        //Method that contains signin view
        //<Summary>
        public IActionResult SignIn()
        {
            return View();
        }

        //<Summary>
        //endpoint to call login process
        //<Summary>
        public async Task<IActionResult> Login(string? emailLog, string? passwordLog)
        {
            if (await EmailUsed(emailLog) || emailLog.IsNullOrEmpty())
                return RedirectToAction("Index");
            await _researchersServices.LoginProcess(emailLog, passwordLog);

            return RedirectToAction("MyJournals");
        }

        public async Task<IActionResult> SignInProcess(string? emailLog, string? passwordLog)
        {
            if (await EmailUsed(emailLog) || emailLog.IsNullOrEmpty())
                return RedirectToAction("SignIn");

            return RedirectToAction("MyJournals");
        }

        //<Summary>
        //verifies that email is not being used already
        //<Summary>

        public async Task<bool> EmailUsed(string email)
        {
            IEnumerable<string> emailsDB = await _dbContext.Researchers.Select(x => x.Email).ToListAsync();

            if (emailsDB.Contains(email))
            {
                return true;
            }

            return false;
        }
    }
}
