using Journals_System.Models.Database;
using Journals_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Journals_System.Controllers
{
    public class JournalsController : Controller
    {
        private readonly dbContext _dbContext;
        private readonly IJournalsServices _journalsServices;

        public JournalsController(dbContext dbContext, IJournalsServices journalsServices)
        {
            _dbContext = dbContext;
            _journalsServices = journalsServices;
        }

        //<Summary>
        //Endpoint to save a newJournal
        //<Summary>
        public async Task<IActionResult> UploadJournal(IFormFile NewJournal, string Title)
        {
            if (NewJournal == null && NewJournal.Length == 0)
            {
                return RedirectToAction("MyJournals", "Home");
            }
            await _journalsServices.UploadJournal(NewJournal, Title, (int)HttpContext.Session.GetInt32("researcherId"));
            return RedirectToAction("MyJournals", "Home");
        }
    }
}
