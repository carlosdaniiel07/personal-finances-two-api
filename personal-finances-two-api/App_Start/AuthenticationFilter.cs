using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

using personal_finances_two_api.Services;

namespace personal_finances_two_api
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        private AuthService _authService = new AuthService();

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            HttpResponseMessage errorHttpResponse = null;

            if (actionContext.Request.Headers.Contains("token"))
            {
                var token = actionContext.Request.Headers.GetValues("token").First();

                if (!_authService.IsValidToken(token))
                {
                    errorHttpResponse = new HttpResponseMessage();
                    errorHttpResponse.StatusCode = HttpStatusCode.Unauthorized;
                    errorHttpResponse.ReasonPhrase = "Bad credentials";
                }
            }      
            else
            {
                errorHttpResponse = new HttpResponseMessage();
                errorHttpResponse.StatusCode = HttpStatusCode.BadRequest;
                errorHttpResponse.ReasonPhrase = "You need to send your token on the request";
            }

            if (errorHttpResponse != null)
                actionContext.Response = errorHttpResponse;
        }
    }
}