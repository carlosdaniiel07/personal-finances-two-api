using System.Collections.Generic;

using personal_finances_two_api.Models;
using personal_finances_two_api.Repositories;

namespace personal_finances_two_api.Services
{
    public class AccountService
    {
        private AccountRepository _repository = new AccountRepository();

        public IEnumerable<Account> GetAll ()
        {
            return _repository.GetAll();
        }

        public Account Get(int id)
        {
            return _repository.Get(id);
        }
    }
}