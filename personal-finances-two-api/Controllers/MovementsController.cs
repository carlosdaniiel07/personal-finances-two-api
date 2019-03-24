using System.Collections.Generic;
using System.Web.Http;

using personal_finances_two_api.Models;
using personal_finances_two_api.Services;

namespace personal_finances_two_api.Controllers
{
    public class MovementsController : ApiController
    {
        private MovementService _service = new MovementService();

        // GET api/<controller>
        public IEnumerable<Movement> Get()
        {
            return _service.GetAll();
        }

        // GET api/<controller>/5
        public Movement Get(int id)
        {
            return _service.Get(id);
        }
    }
}