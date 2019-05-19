using System;
using System.Linq;
using System.Collections.Generic;

using personal_finances_two_api.Services.Exceptions;
using personal_finances_two_api.Models;
using personal_finances_two_api.Models.Enums;
using personal_finances_two_api.Models.RequestModel;
using personal_finances_two_api.Repositories;

namespace personal_finances_two_api.Services
{
    public class InvoiceService
    {
        private InvoiceRepository _repository = new InvoiceRepository();

        private MovementRepository _movementRepository = new MovementRepository();
        private CreditCardService _creditCardService = new CreditCardService();
        private CategoryService _categoryService = new CategoryService();

        public IEnumerable<Movement> GetMovements (int invoiceId)
        {
            return _movementRepository.GetByInvoice(invoiceId);
        }

        public Invoice Get (int id)
        {
            var invoice = _repository.Get(id);

            if (invoice != null)
                return invoice;
            else
                throw new ObjectNotFoundException($"Not found an invoice with Id {id}");
        }

        public Invoice Get (int creditCardId, string reference)
        {
            var invoice = _repository.Get(creditCardId, reference);

            if (invoice != null)
                return invoice;
            else
                throw new ObjectNotFoundException($"Not found a {reference} invoice from this credit card");
        }

        public void Insert(Invoice invoice)
        {
            _repository.Insert(invoice);
        }


        public void Pay (int invoiceId, InvoicePaymentModel invoicePaymentModel)
        {
            var invoice = Get(invoiceId);
            
            if (invoice.InvoiceStatus.Equals(InvoiceStatus.Pending))
            {
                var _movementService = new MovementService();
                var paymentCategory = _categoryService.GetPaymentCategory();
                var paymentSubcategories = _categoryService.GetSubcategories(paymentCategory.Id);

                invoice.PaymentDate = invoicePaymentModel.AccountingDate;
                invoice.InvoiceStatus = InvoiceStatus.Paid;

                var movement = new Movement
                {
                    Type = "D",
                    Description = $"Payment of credit card invoice #{invoiceId} - credit card: {invoice.CreditCard.Name}",
                    AccountingDate = invoicePaymentModel.AccountingDate,
                    AccountId = invoicePaymentModel.AccountId,
                    Value = invoicePaymentModel.Value,
                    MovementStatus = invoicePaymentModel.MovementStatus,
                    AutomaticallyLaunch = invoicePaymentModel.AutomaticallyLaunch,
                    Observation = invoicePaymentModel.Observation,
                    CategoryId = paymentCategory.Id,
                    SubcategoryId = paymentSubcategories.FirstOrDefault(s => s.Name.Equals("Credit card")).Id
                };

                _repository.Update(invoice);
                _movementService.Insert(movement);
                _movementService.LaunchMovement(GetMovements(invoice.Id), false);
            }
            else
            {
                throw new Exceptions.InvalidOperationException("This invoice alright is paid or is not closed yet");
            }
        }

        public void Close (int invoiceId)
        {
            var invoice = Get(invoiceId);

            if (invoice.InvoiceStatus.Equals(InvoiceStatus.NotClosed))
            {
                invoice.Closed = true;
                invoice.InvoiceStatus = InvoiceStatus.Pending;

                _repository.Update(invoice);
            }
            else
            {
                throw new Exceptions.InvalidOperationException("This invoice already is closed");
            }
        }

        public void Open (int invoiceId)
        {
            var invoice = Get(invoiceId);

            if (invoice.InvoiceStatus.Equals(InvoiceStatus.Pending))
            {
                invoice.Closed = false;
                invoice.InvoiceStatus = InvoiceStatus.NotClosed;

                _repository.Update(invoice);
            }
            else
            {
                throw new Exceptions.InvalidOperationException("This invoice already is paid or is not closed yet");
            }
        }

        public static string GetInvoiceReferenceByAccountingDate(int creditCardClosureDay, DateTime accountingDate)
        {
            List<DateTime[]> ranges = new List<DateTime[]>();
            var accountingYear = accountingDate.Year;

            // Range (min date x max date)
            for (var monthNumber = 1; monthNumber <= 12; monthNumber++)
            {
                DateTime minDate, maxDate;
                int day, month, year;

                // Min date
                if (monthNumber.Equals(1))
                {
                    year = accountingYear - 1;
                    month = 12;
                }
                else
                {
                    year = accountingYear;
                    month = monthNumber - 1;
                }

                day = (DateTime.DaysInMonth(year, month) < creditCardClosureDay ? DateTime.DaysInMonth(year, month) : creditCardClosureDay);
                minDate = new DateTime(year, month, day);

                // Max date
                year = accountingYear;
                month = monthNumber;
                day = (DateTime.DaysInMonth(year, month)) < creditCardClosureDay ? DateTime.DaysInMonth(year, month) : creditCardClosureDay;

                maxDate = new DateTime(year, month, day);

                ranges.Add(new DateTime[] { minDate, maxDate });
            }

            foreach (var range in ranges)
                if (accountingDate > range[0] && accountingDate <= range[1])
                    return string.Concat(range[1].ToString("MMM"), "/", range[1].ToString("yyyy"));

            return string.Empty;
        }

        public Invoice GenerateInvoice (CreditCard creditCard, DateTime accountingDate)
        {
            var reference = GetInvoiceReferenceByAccountingDate(int.Parse(creditCard.InvoiceClosure), accountingDate);
            var dueDate = DateTime.ParseExact($"{creditCard.PayDay}/{reference}", "d/MMM/yyyy",
                System.Globalization.CultureInfo.InstalledUICulture).AddMonths(1);

            return new Invoice
            {
                Reference = reference,
                MaturityDate = dueDate,
                PaymentDate = null,
                Closed = false,
                InvoiceStatus = InvoiceStatus.NotClosed,
                CreditCardId = creditCard.Id
            };
        }
    }
}