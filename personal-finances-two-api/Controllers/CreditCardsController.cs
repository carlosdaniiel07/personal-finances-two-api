using System;
using System.Collections.Generic;
using System.Web.Http;

using personal_finances_two_api.Models;
using personal_finances_two_api.Services;
using personal_finances_two_api.Services.Exceptions;

namespace personal_finances_two_api.Controllers
{
    [AuthenticationFilter]
    [RoutePrefix("api/credit-cards")]
    public class CreditCardsController : ApiController
    {
        private CreditCardService _service = new CreditCardService();

        // GET api/credit-cards
        [Route("")]
        public IEnumerable<CreditCard> Get()
        {
            return _service.GetAll();
        }

        // GET api/credit-cards/<id>
        [Route("{id:int}")]
        public CreditCard Get (int id)
        {
            return _service.Get(id);
        }

        // GET api/credit-cards/<id>/invoices
        [Route("{id:int}/invoices")]
        public IEnumerable<Invoice> GetInvoices (int id)
        {
            return _service.GetInvoices(id);
        }

        // POST api/credit-cards
        [HttpPost]
        [Route("")]
        public IHttpActionResult AddCreditCard (CreditCard obj)
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

        // PUT api/credit-cards
        [HttpPut]
        [Route("")]
        public IHttpActionResult UpdateCreditCard(CreditCard obj)
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

        // DELETE api/credit-cards/<id>
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteCreditCard (int id)
        {
            try
            {
                _service.Delete(id);
                return Ok();
            }
            catch (ObjectNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}