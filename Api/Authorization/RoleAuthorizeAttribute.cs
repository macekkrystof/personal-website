using Microsoft.Azure.WebJobs.Host;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalWebsite.Api.Authorization
{
    internal class RoleAuthorizeAttribute : FunctionInvocationFilterAttribute
    {
        private readonly string[] _validRoles;

        public RoleAuthorizeAttribute(params string[] validRoles)
        {
            _validRoles = validRoles;
        }

        public override async Task OnExecutingAsync(FunctionExecutingContext executingContext, CancellationToken cancellationToken)
        {
            if (!executingContext.Arguments.ContainsKey("principal"))
            {
                throw new AuthorizationException("Authentication failed. Missing claims.");
            }

            var claimsPrincipal = (ClaimsPrincipal)executingContext.Arguments["principal"];
            var roles = claimsPrincipal.Claims.Where(e => e.Type == "roles").Select(e => e.Value);

            var isMember = roles.Intersect(_validRoles).Count() > 0;
            if (!isMember)
            {
                throw new AuthorizationException("Authentication failed. User not assigned to one of the required roles.");
            }
        }
    }
}
