using System.Collections.Generic;
using System.Threading.Tasks;
using ERPBackend.Entities.Models;

namespace ERPBackend.Contracts
{
    public interface IFileItemRepository
    {
        Task<IEnumerable<FileItem>> GetAllItemsAsync();
        Task<FileItem> GetItemByIdAsync(int itemId);
        void CreateItem(FileItem item);
        void UpdateItem(FileItem item);
        void DeleteItem(FileItem item);
        Task<IEnumerable<FileItem>> GetItemsByProductId(int productId);
        Task<IEnumerable<FileItem>> GetItemsByProductIdAndType(int productId, FileType type);
    }
}