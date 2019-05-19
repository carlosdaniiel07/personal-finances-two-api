using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using personal_finances_two_api.Models;

namespace personal_finances_two_api.Repositories
{
    public class CategoryRepository
    {
        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Category> GetAll ()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Categories.Where(c => c.Enabled).ToList();
            }
        }

        /// <summary>
        /// Get all categories by Name
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Category> GetAll (string name)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Categories.Where(c => c.Name.Equals(name) && c.Enabled).ToList();
            }
        }

        /// <summary>
        /// Get all categories by Name and Type
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Category> GetAll(string name, string type)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Categories.Where(c => c.Name.Equals(name) &&  c.Type.Equals(type) && c.Enabled).ToList();
            }
        }

        /// <summary>
        /// Get a category by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Category Get (int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Categories.SingleOrDefault(c => c.Id.Equals(id) && c.Enabled);
            }
        }

        /// <summary>
        /// Insert a category
        /// </summary>
        /// <param name="category"></param>
        public void Insert (Category category)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Update an existing category
        /// </summary>
        /// <param name="category"></param>
        public void Update (Category category)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Entry(category).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}