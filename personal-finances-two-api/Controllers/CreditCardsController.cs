using System.Collections.Generic;
using System.Web.Http;

using personal_finances_two_api.Models;
using personal_finances_two_api.Services;

namespace personal_finances_two_api.Controllers
{
    public class CreditCardsController : ApiController
    {
        private CreditCardService _service = new CreditCardService();

        // GET api/<controller>
        public IEnumerable<CreditCard> Get()
        {
            return _service.GetAll();
        }

        // GET api/<controller>/5
        public CreditCard Get(int id)
        {
            return _service.Get(id);
        }
    }
}