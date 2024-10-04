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

        public HomeController(dbContext dbContext, IResearchersServices researchersServices)
        {
            _dbContext = dbContext;
            _researchersServices = researchersServices;
        }

        //<Summary>
        //Main View
        //<Summary>
        public IActionResult Index()
        {
            return View();
        }

        //<Summary>
        //Method that obtains researcher in session journals
        //<Summary>
        public IActionResult MyJournals()
        {
            ViewData["researcherName"] = HttpContext.Session.GetString("researcherName");
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
            if (emailLog.IsNullOrEmpty() || passwordLog.IsNullOrEmpty())
                return View("Index");
            Researchers researcher = await _researchersServices.LoginProcess(emailLog, passwordLog);

            if(researcher == null)
                return View("Index");

            SetSessionVariables(researcher);

            return RedirectToAction("MyJournals");
        }

        //<Summary>
        //endpoint to call signin process
        //<Summary>
        public async Task<IActionResult> SignInProcess(string FullNameSignIn, string? emailLog, string? passwordLog)
        {
            if (await EmailUsed(emailLog))
            {
                ViewData["Message"] = "The email already exists, use another one";
                return View("SignIn");
            }

            if (emailLog.IsNullOrEmpty() || passwordLog.IsNullOrEmpty())
                return View("SignIn");


            Researchers newResearcher = await _researchersServices.SigninProcess(FullNameSignIn, emailLog, passwordLog);

            SetSessionVariables(newResearcher);

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

        //<Summary>
        //Sets the session variables
        //<Summary>
        public void SetSessionVariables(Researchers researcher)
        {
            HttpContext.Session.SetInt32("researcherId", researcher.IdResearcher);
            HttpContext.Session.SetString("researcherName", researcher.FullName);
        }

        //<Summary>
        //Clears the session variables and logout
        //<Summary>
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
