using System.Collections.Generic;
using System.Linq;
using ERPBackend.Contracts;
using ERPBackend.Entities;
using ERPBackend.Entities.Models;

namespace ERPBackend.Repositories
{
    public class StandardProductCategoryRepository : RepositoryBase<StandardProductCategory>, IStandardProductCategoryRepository
    {
        public StandardProductCategoryRepository(ERPContext erpContext) : base(erpContext)
        {

        }
        public IEnumerable<StandardProductCategory> GetAllCategories()
        {
            return FindAll()
                .OrderBy(category => category.Name)
                .ToList();
        }

        public StandardProductCategory GetCategoryById(int categoryId)
        {
            return FindByCondition(category => category.StandardProductCategoryId.Equals(categoryId)).FirstOrDefault();
        }
        public void CreateCategory(StandardProductCategory category)
        {
            Create(category);
        }

        public void DeleteCategory(StandardProductCategory category)
        {
            Delete(category);
        }

        public void UpdateCategory(StandardProductCategory category)
        {
            Update(category);
        }
    }
}