using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

using personal_finances_two_api.Services;
using personal_finances_two_api.Models.Enums;

namespace personal_finances_two_api.Models
{
    public class CreditCard
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(2)]
        public string InvoiceClosure { get; set; }

        [Required]
        [StringLength(2)]
        public string PayDay { get; set; }

        public double Limit { get; set; }

        public bool Enabled { get; set; }

        public double RemainingLimit
        {
            get
            {
                var totalInvoices = new CreditCardService().GetInvoices(Id).Where(i => !i.InvoiceStatus.Equals(InvoiceStatus.Paid)).Sum(i => i.TotalValue);
                return Limit - totalInvoices;
            }
        }

        [JsonIgnore]
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}