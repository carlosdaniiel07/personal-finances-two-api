using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using personal_finances_two_api.Models;

namespace personal_finances_two_api.Repositories
{
    public class AccountRepository
    {
        /// <summary>
        /// Get all accounts
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Account> GetAll ()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Accounts.Where(a => a.Enabled).ToList();
            }
        }

        /// <summary>
        /// Get all accounts by Name
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Account> GetAll (string name)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Accounts.Where(a => a.Name.Equals(name) && a.Enabled).ToList();
            }
        }

        /// <summary>
        /// Get an account by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Account Get (int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Accounts.SingleOrDefault(a => a.Id.Equals(id) && a.Enabled);
            }
        }

        /// <summary>
        /// Insert a new account
        /// </summary>
        /// <param name="account">An account to be inserted</param>
        public void Insert (Account account)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Accounts.Add(account);
                context.SaveChanges();
            }

        }

        /// <summary>
        /// Update an existing account
        /// </summary>
        /// <param name="account"></param>
        public void Update (Account account)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Entry(account).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Update collection of accounts
        /// </summary>
        /// <param name="account"></param>
        public void Update (IEnumerable<Account> accounts)
        {
            using (AppDbContext context = new AppDbContext())
            {
                foreach (var account in accounts)
                    context.Entry(account).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}