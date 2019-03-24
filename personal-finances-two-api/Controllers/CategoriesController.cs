using System.Collections.Generic;
using System.Web.Http;

using personal_finances_two_api.Models;
using personal_finances_two_api.Services;

namespace personal_finances_two_api.Controllers
{
    public class CategoriesController : ApiController
    {
        private CategoryService _service = new CategoryService();

        // GET api/<controller>
        public IEnumerable<Category> Get()
        {
            return _service.GetAll();
        }

        // GET api/<controller>/5
        public Category Get(int id)
        {
            return _service.Get(id);
        }
    }
}