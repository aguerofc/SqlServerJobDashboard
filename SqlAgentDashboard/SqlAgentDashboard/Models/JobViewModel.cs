namespace SqlAgentDashboard.Models
{
    public class JobViewModel
    {
        public string? JobId { get; set; }
        public string? JobName { get; set; }
        public string? LastRunDateTime { get; set; }
        public string? LastRunStatus { get; set; }
        public string? LastRunDuration {  get; set; }
        public string? LastRunStatusMessage { get; set; }
        public string? NextRunDateTime { get; set; }


    }
}
