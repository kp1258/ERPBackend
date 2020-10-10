using System.Collections.Generic;
using ERPBackend.Entities.Models;

namespace ERPBackend.Contracts
{
    public interface IStandardProductCategoryRepository : IRepositoryBase<StandardProductCategory>
    {
        IEnumerable<StandardProductCategory> GetAllCategories();
        StandardProductCategory GetCategoryById(int categoryId);
        void CreateCategory(StandardProductCategory category);
        void UpdateCategory(StandardProductCategory category);
        void DeleteCategory(StandardProductCategory category);
    }
}