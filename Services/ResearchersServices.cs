using Journals_System.Models.Database;

namespace Journals_System.Services
{
    public interface IResearchersServices
    {
        Task LoginProcess(string email, string password);
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
        async Task IResearchersServices.LoginProcess(string email, string password)
        {

        }
    }
}
