using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;

using System.Web.Http;

using personal_finances_two_api.Models;
using personal_finances_two_api.Services;
using personal_finances_two_api.Services.Exceptions;

namespace personal_finances_two_api.Controllers
{
    [RoutePrefix("api/accounts")]
    public class AccountsController : ApiController
    {
        private AccountService _service = new AccountService();

        // GET api/accounts
        [Route("")]
        public IEnumerable<Account> Get ()
        {
            return _service.GetAll();
        }

        // GET api/accounts/<id>
        [Route("{id:int}")]
        public Account Get (int id)
        {
            return _service.Get(id);            
        }

        // GET api/accounts/<id>/movements
        [Route("{id:int}/movements")]
        public IEnumerable<Movement> GetAccountMovements (int id)
        {
            return _service.GetMovements(id);
        }

        // POST api/accounts
        [HttpPost]
        [Route("")]
        public IHttpActionResult AddAccount (Account obj)
        {
            try
            {
                _service.Insert(obj);
                return Ok();
            }
            catch (ObjectAlreadyExistsException e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/accounts
        [HttpPut]
        [Route("")]
        public IHttpActionResult UpdateAccount (Account obj)
        {
            try
            {
                _service.Update(obj);
                return Ok();
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}