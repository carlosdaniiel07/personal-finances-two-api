using System.Collections.Generic;

using System.Linq;

using personal_finances_two_api.Services.Exceptions;
using personal_finances_two_api.Models;
using personal_finances_two_api.Repositories;

namespace personal_finances_two_api.Services
{
    public class AccountService
    {
        private AccountRepository _repository = new AccountRepository();
        private MovementRepository _movementRepository = new MovementRepository();

        public IEnumerable<Account> GetAll ()
        {
            return _repository.GetAll();
        }

        public Account Get (int id)
        {
            var obj = _repository.Get(id);

            if (obj != null)
                return obj;
            else
                throw new ObjectNotFoundException($"Not found an account with ID {id}");
        }

        public IEnumerable<Movement> GetMovements (int accountId)
        {
            return _movementRepository.GetByAccount(accountId);
        }

        public void Insert (Account account)
        {
            account.Balance = account.InitialBalance;
            account.Enabled = true;

            var alreadyExists = _repository.Get(account.Name) != null;

            if (!alreadyExists)
                _repository.Insert(account);
            else
                throw new ObjectAlreadyExistsException($"Already exists an account with the name {account.Name}");
        } 

        public void Update (Account account)
        {
            var currentAccount = Get(account.Id);
            var quantity = _repository.GetAll(account.Name).Count(a => !a.Id.Equals(currentAccount.Id));

            account.Enabled = true;
            account.Balance = currentAccount.Balance;

            if (quantity.Equals(0))
                _repository.Update(account);
            else
                throw new ObjectAlreadyExistsException($"Already exists an account with the name {account.Name}");
        }
    }
}