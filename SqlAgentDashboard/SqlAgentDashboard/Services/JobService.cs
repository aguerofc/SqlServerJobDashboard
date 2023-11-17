using Dapper;
using SqlAgentDashboard.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SqlAgentDashboard.Services
{
    public class JobService : IJobService
    {
        private readonly string _connectionString;

        public JobService(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Get list of sql jobs
        /// </summary>
        /// <returns>List of jobs</returns>
        public async Task<IEnumerable<JobViewModel>>  GetJobs()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<JobViewModel>("dbo.ETLGetJobFlowStatus", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        /// <summary>
        /// Execute job by name
        /// </summary>
        /// <param name="name">Job name</param>
        /// <returns>Job execution</returns>
        public async Task<int> ExecuteJob(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Execute("msdb.dbo.sp_start_job", new { @job_name = name.Trim() }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}