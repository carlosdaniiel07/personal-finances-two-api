using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using personal_finances_two_api.Models;

namespace personal_finances_two_api.Repositories
{
    public class ProjectRepository
    {
        /// <summary>
        /// Get all projects
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Project> GetAll ()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Projects.Where(p => p.Enabled).ToList();
            }
        }

        /// <summary>
        /// Get all projects by name
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Project> GetAll (string name)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Projects.Where(p => p.Name.Equals(name) && p.Enabled).ToList();
            }
        }

        /// <summary>
        /// Get a project by Id
        /// </summary>
        /// <returns></returns>
        public Project Get (int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Projects.SingleOrDefault(p => p.Id.Equals(id) && p.Enabled);
            }
        }

        /// <summary>
        /// Insert a new Project 
        /// </summary>
        /// <param name="project"></param>
        public void Insert (Project project)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Projects.Add(project);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Update a project
        /// </summary>
        /// <param name="project"></param>
        public void Update (Project project)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Entry(project).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}