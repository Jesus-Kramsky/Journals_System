using Journals_System.Models.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Journals_System.Controllers
{
    public class ResearchersController : Controller
    {
        private readonly dbContext _dbContext;

        public ResearchersController(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //<Summary>
        //Gets the selected researcher journals to visualize
        //<Summary>
        public async Task<IActionResult> Journals(int idResearcher)
        {
            ViewData["researcherName"] = await _dbContext.Researchers.Where(x => x.IdResearcher == idResearcher).Select(x => x.FullName).FirstOrDefaultAsync();
            ViewData["researcherJournals"] = await _dbContext.JournalsFiles.Where(x => x.IdResearcher == idResearcher).ToListAsync();
            return View();
        }

        //<Summary>
        //Inserts a new subscription
        //<Summary>
        public async Task<IActionResult> Subscribe(int idFollowed)
        {
            Subscriptions newSub = new Subscriptions()
            {
                SubscriberId = (int)HttpContext.Session.GetInt32("researcherId"),
                FollowedId = idFollowed
            };
            await _dbContext.AddAsync(newSub);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Researchers", "Home");
        }
    }
}
