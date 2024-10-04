using Journals_System.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace Journals_System.Services
{
    public interface IResearchersServices
    {
        Task<Researchers> LoginProcess(string email, string password);
        Task<Researchers> SigninProcess(string fullname, string email, string password);
    }
    public class ResearchersServices : IResearchersServices
    {
        private readonly dbContext _dbContext;

        public ResearchersServices(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //<Summary>
        //Method that contains the validations of login process
        //<Summary>
        async Task<Researchers> IResearchersServices.LoginProcess(string email, string password)
        {
            //Researchers researcher = await;

            return await _dbContext.Researchers.Where(x => x.Email.Equals(email) && x.Password.Equals(password)).FirstOrDefaultAsync();
        }

        //<Summary>
        //Method that contains the process of signin process
        //<Summary>
        async Task<Researchers> IResearchersServices.SigninProcess(string fullname, string email, string password)
        {
            Researchers newResearcher = new Researchers()
            {
                FullName = fullname,
                Email = email,
                Password = password
            };
            await _dbContext.AddAsync(newResearcher);
            await _dbContext.SaveChangesAsync();

            return newResearcher;
        }
    }
}
