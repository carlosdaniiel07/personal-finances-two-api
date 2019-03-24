using System.Collections.Generic;

using personal_finances_two_api.Models;
using personal_finances_two_api.Repositories;

namespace personal_finances_two_api.Services
{
    public class SubcategoryService
    {
        private SubcategoryRepository _repository = new SubcategoryRepository();

        public IEnumerable<Subcategory> GetAll ()
        {
            return _repository.GetAll();
        }

        public Subcategory Get(int id)
        {
            return _repository.Get(id);
        }
    }
}