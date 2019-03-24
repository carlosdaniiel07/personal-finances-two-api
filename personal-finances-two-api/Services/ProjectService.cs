using System.Collections.Generic;

using personal_finances_two_api.Models;
using personal_finances_two_api.Repositories;

namespace personal_finances_two_api.Services
{
    public class ProjectService
    {
        private ProjectRepository _repository = new ProjectRepository();

        public IEnumerable<Project> GetAll ()
        {
            return _repository.GetAll();
        }

        public Project Get(int id)
        {
            return _repository.Get(id);
        }
    }
}