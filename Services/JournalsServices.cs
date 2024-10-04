using Journals_System.Models.Database;

namespace Journals_System.Services
{
    public interface IJournalsServices
    {
        Task UploadJournal(IFormFile NewJournal, string title, int authorId);
    }
    public class JournalsServices : IJournalsServices
    {
        private readonly dbContext _dbContext;
        private readonly IWebHostEnvironment _env;

        public JournalsServices(dbContext dbContext, IWebHostEnvironment env)
        {
            _dbContext = dbContext;
            _env = env;
        }

        //<Summary>
        //Save File in server and Database
        //<Summary>
        async Task IJournalsServices.UploadJournal(IFormFile NewJournalinfo, string title, int authorId)
        {
            
            JournalsFiles NewJournal = await SaveJournalServer(NewJournalinfo);
            NewJournal.Title = title;
            NewJournal.IdResearcher = authorId;
            await _dbContext.AddAsync(NewJournal);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<JournalsFiles> SaveJournalServer(IFormFile NewJournal)
        {
            JournalsFiles NewJournals = new JournalsFiles();
            // Get file name and content
            var fileName = Path.GetFileName(NewJournal.FileName);
            var filePath = Path.Combine(_env.WebRootPath, "JournalsFiles", fileName);

            NewJournals.FileName = fileName;
            // Save File in server
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await NewJournal.CopyToAsync(stream);
            }

            return NewJournals;

        }
    }
}
