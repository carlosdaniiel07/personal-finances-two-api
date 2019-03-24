using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using personal_finances_two_api.Models;

namespace personal_finances_two_api.Repositories
{
    public class MovementRepository
    {
        /// <summary>
        /// Get all movements
        /// </summary
        /// <returns></returns>
        public IEnumerable<Movement> GetAll ()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Movements
                    .Include(m => m.Account)
                    .Include(m => m.Category)
                    .Include(m => m.Subcategory)
                    .Include(m => m.Project)
                    .Include(m => m.Invoice.CreditCard)
                .ToList();
            }
        }

        /// <summary>
        /// Get a movement by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Movement Get (int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Movements
                    .Include(m => m.Account)
                    .Include(m => m.Category)
                    .Include(m => m.Subcategory)
                    .Include(m => m.Project)
                    .Include(m => m.Invoice.CreditCard)
                .SingleOrDefault(m => m.Id.Equals(id));
            }
        }

        /// <summary>
        /// Insert a new movement
        /// </summary>
        /// <param name="movement"></param>
        public void Insert (Movement movement)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Movements.Add(movement);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Update a movement
        /// </summary>
        /// <param name="movement"></param>
        public void Update (Movement movement)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Entry(movement).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Update a collection of movements
        /// </summary>
        /// <param name="movement"></param>
        public void Update (IEnumerable<Movement> movements)
        {
            using (AppDbContext context = new AppDbContext())
            {
                foreach (var movement in movements)
                    context.Entry(movement).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Delete a movement
        /// </summary>
        /// <param name="movement"></param>
        public void Remove (Movement movement)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Entry(movement).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}