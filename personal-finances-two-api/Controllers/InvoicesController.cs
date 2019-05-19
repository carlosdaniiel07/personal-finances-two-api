using System;
using System.Collections.Generic;
using System.Web.Http;

using personal_finances_two_api.Models;
using personal_finances_two_api.Models.RequestModel;
using personal_finances_two_api.Services;

namespace personal_finances_two_api.Controllers
{
    [AuthenticationFilter]
    [RoutePrefix("api/invoices")]
    public class InvoicesController : ApiController
    {
        private InvoiceService _service = new InvoiceService();

        // GET api/invoices/<id>
        [Route("{id:int}")]
        public Invoice Get (int id)
        {
            return _service.Get(id);
        }

        // GET api/invoices/<id>/movements
        [Route("{id:int}/movements")]
        public IEnumerable<Movement> GetMovements (int id)
        {
            return _service.GetMovements(id);    
        }

        // PUT api/invoices/close/<id>
        [HttpPut]
        [Route("close/{id:int}")]
        public IHttpActionResult CloseInvoice(int id)
        {
            try
            {
                _service.Close(id);
                return Ok();
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/invoices/open/<id>
        [HttpPut]
        [Route("open/{id:int}")]
        public IHttpActionResult OpenInvoice (int id)
        {
            try
            {
                _service.Open(id);
                return Ok();
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("pay/{id:int}")]
        public IHttpActionResult PayInvoice ([FromUri] int id, [FromBody] InvoicePaymentModel invoicePaymentModel)
        {
            try
            {
                _service.Pay(id, invoicePaymentModel);
                return Ok();
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}