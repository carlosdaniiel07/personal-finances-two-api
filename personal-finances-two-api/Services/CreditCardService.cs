using System.Collections.Generic;

using personal_finances_two_api.Models;
using personal_finances_two_api.Repositories;

namespace personal_finances_two_api.Services
{
    public class CreditCardService
    {
        private CreditCardRepository _repository = new CreditCardRepository();

        public IEnumerable<CreditCard> GetAll ()
        {
            return _repository.GetAll();
        }

        public CreditCard Get(int id)
        {
            return _repository.Get(id);
        }
    }
}