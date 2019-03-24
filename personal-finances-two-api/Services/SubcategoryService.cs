using System.Collections.Generic;

using personal_finances_two_api.Models;
using personal_finances_two_api.Repositories;

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
            return _repository.Get(id);
        }
    }
}