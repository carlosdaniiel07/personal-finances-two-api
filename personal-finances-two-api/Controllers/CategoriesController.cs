using System;
using System.Collections.Generic;
using System.Web.Http;

using personal_finances_two_api.Models;
using personal_finances_two_api.Services;
using personal_finances_two_api.Services.Exceptions;

namespace personal_finances_two_api.Controllers
{
    [AuthenticationFilter]
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

        // POST api/categories
        [Route("")]
        [HttpPost]
        public IHttpActionResult AddCategory (Category obj)
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

        // PUT api/categories
        [Route("")]
        [HttpPut]
        public IHttpActionResult UpdateCategory(Category obj)
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

        // PUT api/categories/<id>
        [Route("{id:int}")]
        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok();
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}