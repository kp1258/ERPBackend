using System.Collections.Generic;
using System.Threading.Tasks;
using ERPBackend.Contracts;
using ERPBackend.Entities;
using ERPBackend.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPBackend.Repositories
{
    public class FileItemRepository : RepositoryBase<FileItem>, IFileItemRepository
    {
        public FileItemRepository(ERPContext erpContext) : base(erpContext)
        {

        }

        public void CreateItem(FileItem item)
        {
            Create(item);
        }

        public void DeleteItem(FileItem item)
        {
            Delete(item);
        }

        public async Task<IEnumerable<FileItem>> GetAllItemsAsync()
        {
            return await FindAll()
                            .ToListAsync();
        }

        public async Task<FileItem> GetItemByIdAsync(int itemId)
        {
            return await FindByCondition(i => i.FileItemId
                            .Equals(itemId))
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<FileItem>> GetItemsByProductId(int productId)
        {
            return await FindByCondition(i => i.CustomProductId
                            .Equals(productId))
                            .ToListAsync();
        }

        public async Task<IEnumerable<FileItem>> GetItemsByProductIdAndType(int productId, FileType type)
        {
            return await FindByCondition(i => i.CustomProductId.Equals(productId)
                            && i.Type == type)
                            .ToListAsync();
        }

        public void UpdateItem(FileItem item)
        {
            Update(item);
        }
    }
}