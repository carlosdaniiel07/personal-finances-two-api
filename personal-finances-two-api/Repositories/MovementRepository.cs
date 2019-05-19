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
        /// Get movements by account Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Movement> GetByAccount (int accountId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Movements
                    .Include(m => m.Account)
                    .Include(m => m.Category)
                    .Include(m => m.Subcategory)
                    .Include(m => m.Project)
                    .Include(m => m.Invoice.CreditCard)
                .Where(m => m.AccountId.Equals(accountId)).ToList();
            }
        }

        /// <summary>
        /// Get movements by category Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Movement> GetByCategory (int categoryId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Movements
                    .Include(m => m.Account)
                    .Include(m => m.Category)
                    .Include(m => m.Subcategory)
                    .Include(m => m.Project)
                    .Include(m => m.Invoice.CreditCard)
                .Where(m => m.CategoryId.Equals(categoryId)).ToList();
            }
        }

        /// <summary>
        /// Get movements by subcategory Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Movement> GetBySubcategory(int subcategoryId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Movements
                    .Include(m => m.Account)
                    .Include(m => m.Category)
                    .Include(m => m.Subcategory)
                    .Include(m => m.Project)
                    .Include(m => m.Invoice.CreditCard)
                .Where(m => m.SubcategoryId.Equals(subcategoryId)).ToList();
            }
        }

        /// <summary>
        /// Get movements by project Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Movement> GetByProject (int projectId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Movements
                    .Include(m => m.Account)
                    .Include(m => m.Category)
                    .Include(m => m.Subcategory)
                    .Include(m => m.Project)
                    .Include(m => m.Invoice.CreditCard)
                .Where(m => m.ProjectId == projectId).ToList();
            }
        }

        /// <summary>
        /// Get movements by invoice Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Movement> GetByInvoice (int invoiceId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Movements
                    .Include(m => m.Account)
                    .Include(m => m.Category)
                    .Include(m => m.Subcategory)
                    .Include(m => m.Project)
                    .Include(m => m.Invoice.CreditCard)
                .Where(m => m.InvoiceId == invoiceId).ToList();
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