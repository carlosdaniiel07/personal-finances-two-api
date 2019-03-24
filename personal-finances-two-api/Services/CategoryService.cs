using System.Collections.Generic;

using personal_finances_two_api.Models;
using personal_finances_two_api.Repositories;

namespace personal_finances_two_api.Services
{
    public class CategoryService
    {
        private CategoryRepository _repository = new CategoryRepository();

        public IEnumerable<Category> GetAll ()
        {
            return _repository.GetAll();
        }

        public Category Get(int id)
        {
            return _repository.Get(id);
        }
    }
}