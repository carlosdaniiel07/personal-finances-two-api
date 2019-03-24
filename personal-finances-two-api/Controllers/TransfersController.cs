using System.Collections.Generic;
using System.Web.Http;

using personal_finances_two_api.Models;
using personal_finances_two_api.Services;

namespace personal_finances_two_api.Controllers
{
    public class TransfersController : ApiController
    {
        private TransferService _service = new TransferService();

        // GET api/<controller>
        public IEnumerable<Transfer> Get()
        {
            return _service.GetAll();
        }

        // GET api/<controller>/5
        public Transfer Get(int id)
        {
            return _service.Get(id);
        }
    }
}