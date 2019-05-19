using System;
using System.Collections.Generic;
using System.Web.Http;

using personal_finances_two_api.Models;
using personal_finances_two_api.Services;
using personal_finances_two_api.Services.Exceptions;

namespace personal_finances_two_api.Controllers
{
    [AuthenticationFilter]
    [RoutePrefix("api/projects")]
    public class ProjectsController : ApiController
    {
        private ProjectService _service = new ProjectService();

        // GET api/projects
        [Route("")]
        public IEnumerable<Project> Get()
        {
            return _service.GetAll();
        }

        // GET api/projects/<id>
        [Route("{id:int}")]
        public Project Get(int id)
        {
            return _service.Get(id);
        }

        // GET api/projects/<id>/movements
        [Route("{id:int}/movements")]
        public IEnumerable<Movement> GetProjectMovements (int id)
        {
            return _service.GetMovements(id);
        }

        // POST api/projects
        [HttpPost]
        [Route("")]
        public IHttpActionResult InsertProject (Project project)
        {
            try
            {
                _service.Insert(project);
                return Ok();
            }
            catch (ObjectAlreadyExistsException e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/projects
        [HttpPut]
        [Route("")]
        public IHttpActionResult UpdateProject(Project project)
        {
            try
            {
                _service.Update(project);
                return Ok();
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/projects/<id>
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteProject(int id)
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