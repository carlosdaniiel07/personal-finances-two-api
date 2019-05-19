using System;
using System.Web.Http;

using personal_finances_two_api.Models;
using personal_finances_two_api.Services;
using personal_finances_two_api.Services.Exceptions;

namespace personal_finances_two_api.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private AuthService _authService = new AuthService();

        // POST: api/auth
        [HttpPost]
        [Route("")]
        public IHttpActionResult AuthUser(User user)
        {
            try
            {
                var jsonObj = new { Token = _authService.Auth(user).Token };
                return Ok(jsonObj);
            }
            catch (ObjectNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
