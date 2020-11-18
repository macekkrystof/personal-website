using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalWebsite.Api.Authorization
{
    public abstract class BaseAuthorizedFunction : IFunctionExceptionFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        protected BaseAuthorizedFunction(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task OnExceptionAsync(FunctionExceptionContext exceptionContext, CancellationToken cancellationToken)
        {
            if (exceptionContext.Exception.InnerException != null && exceptionContext.Exception.InnerException is AuthorizationException)
            {
                _httpContextAccessor.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await _httpContextAccessor.HttpContext.Response.WriteAsync(exceptionContext.Exception.InnerException.Message);
            }
        }
    }
}
