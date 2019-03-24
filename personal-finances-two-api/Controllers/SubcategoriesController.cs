using System.Collections.Generic;
using System.Web.Http;

using personal_finances_two_api.Models;
using personal_finances_two_api.Services;

namespace personal_finances_two_api.Controllers
{
    public class ProjectsController : ApiController
    {
        private ProjectService _service = new ProjectService();

        // GET api/<controller>
        public IEnumerable<Project> Get()
        {
            return _service.GetAll();
        }

        // GET api/<controller>/5
        public Project Get(int id)
        {
            return _service.Get(id);
        }
    }
}