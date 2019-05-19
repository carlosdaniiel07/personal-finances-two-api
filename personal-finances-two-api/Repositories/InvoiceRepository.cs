using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

using personal_finances_two_api.Models;

namespace personal_finances_two_api.Repositories
{
    public class InvoiceRepository
    {
        public IEnumerable<Invoice> GetByCreditCard (int creditCardId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Invoices.Include(i => i.CreditCard).ToList();
            }
        }

        public Invoice Get(int invoiceId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Invoices.Include(i => i.CreditCard).SingleOrDefault(i => i.Id.Equals(invoiceId));
            }
        }

        public Invoice Get (int creditCardId, string reference)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Invoices.SingleOrDefault(i => i.CreditCardId.Equals(creditCardId) && i.Reference.Equals(reference));
            }
        }

        public void Insert (Invoice invoice)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Invoices.Add(invoice);
                context.SaveChanges();
            }
        }

        public void Update (Invoice invoice)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Entry(invoice).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}