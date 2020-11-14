using System.Collections.Generic;
using System.Threading.Tasks;
using ERPBackend.Entities.Models;

namespace ERPBackend.Contracts
{
    public interface IStandardProductCategoryRepository : IRepositoryBase<StandardProductCategory>
    {
        Task<IEnumerable<StandardProductCategory>> GetAllCategoriesAsync();
        Task<StandardProductCategory> GetCategoryByIdAsync(int categoryId);
        void CreateCategory(StandardProductCategory category);
        void UpdateCategory(StandardProductCategory category);
        void DeleteCategory(StandardProductCategory category);
    }
}