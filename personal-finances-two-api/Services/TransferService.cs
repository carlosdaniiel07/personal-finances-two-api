using System.Collections.Generic;

using personal_finances_two_api.Models;
using personal_finances_two_api.Repositories;
using personal_finances_two_api.Services.Exceptions;

namespace personal_finances_two_api.Services
{
    public class TransferService
    {
        private TransferRepository _repository = new TransferRepository();

        public IEnumerable<Transfer> GetAll ()
        {
            return _repository.GetAll();
        }

        public Transfer Get(int id)
        {
            var obj = _repository.Get(id);

            if (obj != null)
                return obj;
            else
                throw new ObjectNotFoundException($"Not found a transfer with ID {id}");
        }
    }
}