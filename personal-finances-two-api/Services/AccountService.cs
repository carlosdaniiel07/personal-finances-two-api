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

        public Account Get (int id, bool canBeDisabledAccount)
        {
            if (canBeDisabledAccount)
                return _repository.Get(id, true);
            else
                return Get(id);
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

        public void Delete (int id)
        {
            var account = Get(id);

            account.Enabled = false;

            _repository.Update(account);
        }

        public void AdjustBalance (int accountId)
        {
            // get an account (can be a disabled account)
            var account = Get(accountId, true);

            var accountMovements = _movementRepository.GetByAccount(accountId);
            var newBalance = (account.InitialBalance + MovementService.TotalCredit(accountMovements.Where(m => m.Invoice == null))) 
                - MovementService.TotalDebit(accountMovements.Where(m => m.Invoice == null));

            account.Balance = newBalance;

            _repository.Update(account);
        }
    }
}