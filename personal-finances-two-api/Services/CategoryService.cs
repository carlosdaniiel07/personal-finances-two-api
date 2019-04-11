using System.Collections.Generic;

using personal_finances_two_api.Models;
using personal_finances_two_api.Repositories;

namespace personal_finances_two_api.Services
{
    public class CategoryService
    {
        private CategoryRepository _repository = new CategoryRepository();
        private MovementRepository _movementRepository = new MovementRepository();
        private SubcategoryRepository _subcategoryRepository = new SubcategoryRepository();

        public IEnumerable<Category> GetAll ()
        {
            return _repository.GetAll();
        }

        public Category Get(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Movement> GetMovements (int categoryId)
        {
            return _movementRepository.GetByCategory(categoryId);
        }

        public IEnumerable<Subcategory> GetSubcategories (int categoryId)
        {
            return _subcategoryRepository.GetByCategory(categoryId);
        }
    }
}