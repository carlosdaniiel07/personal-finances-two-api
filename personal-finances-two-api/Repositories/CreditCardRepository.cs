using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using personal_finances_two_api.Models;

namespace personal_finances_two_api.Repositories
{
    public class CreditCardRepository
    {
        /// <summary>
        /// Get all credit cards
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CreditCard> GetAll ()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.CreditCards.Where(c => c.Enabled).ToList();
            }
        }

        /// <summary>
        /// Get all credit cards
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CreditCard> GetAll (string name)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.CreditCards.Where(c => c.Name.Equals(name) && c.Enabled).ToList();
            }
        }

        /// <summary>
        /// Get a credit card by Id
        /// </summary>
        /// <returns></returns>
        public CreditCard Get (int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.CreditCards.SingleOrDefault(c => c.Id.Equals(id) && c.Enabled);
            }
        }

        /// <summary>
        /// Insert a credit card
        /// </summary>
        /// <param name="creditCard"></param>
        /// <returns></returns>
        public void Insert(CreditCard creditCard)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.CreditCards.Add(creditCard);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Update a credit card
        /// </summary>
        /// <param name="creditCard"></param>
        /// <returns></returns>
        public void Update (CreditCard creditCard)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Entry(creditCard).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}