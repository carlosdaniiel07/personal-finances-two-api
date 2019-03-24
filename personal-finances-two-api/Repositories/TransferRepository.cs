using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using personal_finances_two_api.Models;

namespace personal_finances_two_api.Repositories
{
    public class TransferRepository
    {
        /// <summary>
        /// Get all transfers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Transfer> GetAll ()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Transfers.ToList();
            }
        }

        /// <summary>
        /// Get a transfer by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Transfer Get (int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Transfers.SingleOrDefault(t => t.Id.Equals(id));
            }
        }

        /// <summary>
        /// Insert a transfer
        /// </summary>
        /// <param name="category"></param>
        public void Insert (Transfer transfer)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Transfers.Add(transfer);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Update a transfer
        /// </summary>
        /// <param name="category"></param>
        public void Update (Transfer transfer)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Entry(transfer).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}