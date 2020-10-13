using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPBackend.Contracts;
using ERPBackend.Entities;
using ERPBackend.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPBackend.Repositories
{
    public class StandardProductCategoryRepository : RepositoryBase<StandardProductCategory>, IStandardProductCategoryRepository
    {
        public StandardProductCategoryRepository(ERPContext erpContext) : base(erpContext)
        {

        }
        public async Task<IEnumerable<StandardProductCategory>> GetAllCategoriesAsync()
        {
            return await FindAll()
                            .OrderBy(category => category.Name)
                            .ToListAsync();
        }

        public async Task<StandardProductCategory> GetCategoryByIdAsync(int categoryId)
        {
            return await FindByCondition(category => category.StandardProductCategoryId.Equals(categoryId))
                            .FirstOrDefaultAsync();
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