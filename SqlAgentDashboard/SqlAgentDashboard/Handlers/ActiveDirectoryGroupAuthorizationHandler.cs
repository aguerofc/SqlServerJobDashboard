using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace SqlAgentDashboard.Handlers
{
    public class ActiveDirectoryGroupAuthorizationHandler : AuthorizationHandler<ActiveDirectoryGroupRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ActiveDirectoryGroupRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == requirement.GroupName))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

}
