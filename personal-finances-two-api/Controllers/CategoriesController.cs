using System.Collections.Generic;
using System.Web.Http;

using personal_finances_two_api.Models;
using personal_finances_two_api.Services;

namespace personal_finances_two_api.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        private CategoryService _service = new CategoryService();

        // GET api/categories
        [Route("")]
        public IEnumerable<Category> Get()
        {
            return _service.GetAll();
        }

        [Route("{id:int}")]
        // GET api/categories/<id>
        public Category Get(int id)
        {
            return _service.Get(id);
        }

        // GET api/categories/<id>/movements
        [Route("{id:int}/movements")]
        public IEnumerable<Movement> GetCategoryMovements(int id)
        {
            return _service.GetMovements(id);
        }

        // GET api/categories/<id>/subcategories
        [Route("{id:int}/subcategories")]
        public IEnumerable<Subcategory> GetCategorySubcategories(int id)
        {
            return _service.GetSubcategories(id);
        }
    }
}