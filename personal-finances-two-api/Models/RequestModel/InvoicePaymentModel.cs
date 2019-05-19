using System;

using personal_finances_two_api.Models.Enums;

namespace personal_finances_two_api.Models.RequestModel
{
    public class InvoicePaymentModel
    {
        public string Description { get; set; }
        public DateTime AccountingDate { get; set; }
        public int AccountId { get; set; }
        public double Value { get; set; }
        public MovementStatus MovementStatus { get; set; }
        public bool AutomaticallyLaunch { get; set; }
        public string Observation { get; set; }
    }
}