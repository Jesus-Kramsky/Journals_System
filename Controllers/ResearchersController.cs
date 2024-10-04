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
    }
}
