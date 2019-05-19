using System.Collections.Generic;
using System.Web.Http;
using System;

using personal_finances_two_api.Models;
using personal_finances_two_api.Services;
using personal_finances_two_api.Services.Exceptions;

namespace personal_finances_two_api.Controllers
{
    [AuthenticationFilter]
    [RoutePrefix("api/subcategories")]
    public class SubcategoriesController : ApiController
    {
        private SubcategoryService _service = new SubcategoryService();

        // GET api/subcategories
        [Route("")]
        public IEnumerable<Subcategory> Get()
        {
            return _service.GetAll();
        }

        // GET api/subcategories/<id>
        [Route("{id:int}")]
        public Subcategory Get(int id)
        {
            return _service.Get(id);
        }

        // GET api/subcategories/<id>/movements 
        [Route("{id:int}/movements")]
        public IEnumerable<Movement> GetSubcategoryMovements (int id)
        {
            return _service.GetMovements(id);
        }

        // POST api/subcategories/
        [HttpPost]
        [Route("")]
        public IHttpActionResult AddSubcategory (Subcategory obj)
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

        // PUT api/subcategories/
        [HttpPut]
        [Route("")]
        public IHttpActionResult UpdateSubcategory(Subcategory obj)
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

        // DELETE api/subcategories/<id>
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteSubcategory (int id)
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