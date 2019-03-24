using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

using Newtonsoft.Json;

using personal_finances_two_api.Models.Enums;

namespace personal_finances_two_api.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [StringLength(8, MinimumLength = 8)]
        public string Reference { get; set; }

        public DateTime MaturityDate { get; set; }

        public DateTime? PaymentDate { get; set; }

        public bool Closed { get; set; }

        public InvoiceStatus InvoiceStatus { get; set; }
        
        public CreditCard CreditCard { get; set; }

        [Required]
        [JsonIgnore]
        public int CreditCardId { get; set; }

        [JsonIgnore]
        public ICollection<Movement> Movements { get; set; } = new List<Movement>();
    }
}