using System.Collections.Generic;
using System.Web.Http;

using personal_finances_two_api.Models;
using personal_finances_two_api.Services;

namespace personal_finances_two_api.Controllers
{
    public class SubcategoriesController : ApiController
    {
        private SubcategoryService _service = new SubcategoryService();

        // GET api/<controller>
        public IEnumerable<Subcategory> Get()
        {
            return _service.GetAll();
        }

        // GET api/<controller>/5
        public Subcategory Get(int id)
        {
            return _service.Get(id);
        }
    }
}