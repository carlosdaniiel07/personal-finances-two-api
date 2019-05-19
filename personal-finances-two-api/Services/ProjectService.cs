using System;
using System.Linq;
using System.Collections.Generic;

using personal_finances_two_api.Models;
using personal_finances_two_api.Models.Enums;
using personal_finances_two_api.Repositories;
using personal_finances_two_api.Services.Exceptions;

namespace personal_finances_two_api.Services
{
    public class ProjectService
    {
        private ProjectRepository _repository = new ProjectRepository();
        private MovementRepository _movementRepository = new MovementRepository();

        public IEnumerable<Project> GetAll ()
        {
            return _repository.GetAll();
        }

        public Project Get(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Movement> GetMovements (int projectId)
        {
            return _movementRepository.GetByProject(projectId);
        }

        public void Insert (Project project)
        {
            project.Enabled = true;
            project.StartDate = DateTime.Today;
            project.ProjectStatus = ProjectStatus.InProgress;

            var nameExists = _repository.GetAll(project.Name).Count() > 0;

            if (!nameExists)
                _repository.Insert(project);
            else
                throw new ObjectAlreadyExistsException($"Already exists a project with the name {project.Name}");

        }

        public void Update (Project project)
        {
            project.Enabled = true;
            var exists = _repository.GetAll(project.Name).Count(p => !p.Id.Equals(project.Id)) > 0;

            if (!exists)
                _repository.Update(project);
            else
                throw new ObjectAlreadyExistsException($"Already exists a project with the name {project.Name}");
        }

        public void Delete (int id)
        {
            var project = Get(id);
            project.Enabled = false;

            _repository.Update(project);
        }
    }
}