using System.Collections.Generic;

using personal_finances_two_api.Models;
using personal_finances_two_api.Repositories;

namespace personal_finances_two_api.Services
{
    public class MovementService
    {
        private MovementRepository _repository = new MovementRepository();

        public IEnumerable<Movement> GetAll ()
        {
            return _repository.GetAll();
        }

        public Movement Get(int id)
        {
            return _repository.Get(id);
        }
    }
}