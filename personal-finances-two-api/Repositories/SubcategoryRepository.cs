using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using personal_finances_two_api.Models;

namespace personal_finances_two_api.Repositories
{
    public class SubcategoryRepository
    {
        /// <summary>
        /// Get all subcategories
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Subcategory> GetAll ()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Subcategories
                    .Include(s => s.Category)
                .Where(s => s.Enabled).ToList();
            }
        }

        /// <summary>
        /// Get all subcategories by Name
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Subcategory> GetAll (string name)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Subcategories
                    .Include(s => s.Category)
                .Where(s => s.Name.Equals(name) && s.Enabled).ToList();
            }
        }

        /// <summary>
        /// Get a subcategory by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Subcategory Get (int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Subcategories
                    .Include(s => s.Category)
                .SingleOrDefault(s => s.Id.Equals(id) && s.Enabled);
            }
        }

        /// <summary>
        /// Get all subcategories by category Id
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Subcategory> GetByCategory (int categoryId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Subcategories.Where(s => s.CategoryId.Equals(categoryId) && s.Enabled).ToList();
            }
        }

        /// <summary>
        /// Insert a subcategory
        /// </summary>
        /// <param name="subcategory"></param>
        public void Insert (Subcategory subcategory)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Subcategories.Add(subcategory);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Update a subcategory
        /// </summary>
        /// <param name="subcategory"></param>
        public void Update (Subcategory subcategory)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Entry(subcategory).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}