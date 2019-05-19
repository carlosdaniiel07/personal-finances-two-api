using System.Linq;
using System.Collections.Generic;

using personal_finances_two_api.Models;
using personal_finances_two_api.Repositories;
using personal_finances_two_api.Services.Exceptions;

namespace personal_finances_two_api.Services
{
    public class CreditCardService
    {
        private CreditCardRepository _repository = new CreditCardRepository();
        private InvoiceRepository _invoiceRepository = new InvoiceRepository();

        public IEnumerable<CreditCard> GetAll ()
        {
            return _repository.GetAll();
        }

        public CreditCard Get(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Invoice> GetInvoices (int id)
        {
            return _invoiceRepository.GetByCreditCard(id);
        }

        public void Insert (CreditCard creditCard)
        {
            var exists = _repository.GetAll(creditCard.Name).Count() > 0;
            creditCard.Enabled = true;

            if (!exists)
                _repository.Insert(creditCard);
            else
                throw new ObjectAlreadyExistsException($"Already exists a credit card with the name {creditCard.Name}");
        }

        public void Update (CreditCard creditCard)
        {
            var exists = _repository.GetAll(creditCard.Name).Count(c => !c.Id.Equals(creditCard.Id)) > 0;
            creditCard.Enabled = true;

            if (!exists)
                _repository.Update(creditCard);
            else
                throw new ObjectAlreadyExistsException($"Already exists a credit card with the name {creditCard.Name}");
        }

        public void Delete (int id)
        {
            var creditCard = Get(id);

            creditCard.Enabled = false;

            _repository.Update(creditCard);
        }

        public static bool CanBeUsed (CreditCard creditCard, Movement movement)
        {
            if (movement.Type != "D")
                throw new InvalidOperationException("Credit cards can be used only with expenses movements");

            return true;
        }
    }
}