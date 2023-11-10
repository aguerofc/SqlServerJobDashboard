using SqlAgentDashboard.Models;

namespace SqlAgentDashboard.Services
{
    public interface IJobService
    {
        Task<IEnumerable<JobViewModel>> GetJobs();
        Task<int> ExecuteJob(string name);
    }
}
