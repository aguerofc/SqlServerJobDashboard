using Microsoft.AspNetCore.Authorization;

namespace SqlAgentDashboard.Handlers
{
    public class ActiveDirectoryGroupRequirement : IAuthorizationRequirement
    {
        public string GroupName { get; }

        public ActiveDirectoryGroupRequirement(string groupName)
        {
            GroupName = groupName;
        }
    }

}
