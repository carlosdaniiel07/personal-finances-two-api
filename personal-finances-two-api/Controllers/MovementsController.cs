using System;
using System.Collections.Generic;
using System.Web.Http;

using personal_finances_two_api.Models;
using personal_finances_two_api.Services;
using personal_finances_two_api.Services.Exceptions;

namespace personal_finances_two_api.Controllers
{
    [AuthenticationFilter]
    [RoutePrefix("api/movements")]
    public class MovementsController : ApiController
    {
        private MovementService _service = new MovementService();

        // GET api/movements
        [Route("")]
        public IEnumerable<Movement> Get()
        {
            return _service.GetAll();
        }

        // GET api/movements/<id>
        [Route("{id:int}")]
        public Movement Get(int id)
        {
            return _service.Get(id);
        }

        // POST api/movements
        [HttpPost]
        [Route("")]
        public IHttpActionResult AddMovement(Movement obj)
        {
            try
            {
                _service.Insert(obj);
                return Ok();
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/movements
        [HttpPut]
        [Route("")]
        public IHttpActionResult UpdateMovement(Movement obj)
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

        // PUT api/movements/launch/<id>
        [HttpPut]
        [Route("launch/{id:int}")]
        public IHttpActionResult LaunchMovement (int id)
        {
            try
            {
                _service.Launch(id);
                return Ok();
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/movements/<id>
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteMovement (int id)
        {
            try
            {
                _service.Delete(id);
                return Ok();
            }
            catch (ObjectNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}