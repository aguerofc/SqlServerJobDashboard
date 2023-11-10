﻿using Dapper;
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

        public async Task<IEnumerable<JobViewModel>>  GetJobs()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<JobViewModel>("dbo.GetJobFlowStatus", commandType: CommandType.StoredProcedure).ToList();
            }
        }

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