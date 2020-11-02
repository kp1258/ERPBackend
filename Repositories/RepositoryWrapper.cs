using System.Threading.Tasks;
using ERPBackend.Contracts;
using ERPBackend.Entities;

namespace ERPBackend.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ERPContext _erpContext;
        private IUserRepository _user;
        private IClientRepository _client;
        private IOrderRepository _order;
        private IStandardProductRepository _standardProduct;
        private ICustomProductRepository _customProduct;
        private IStandardProductCategoryRepository _standardProductCategory;
        private IMaterialRepository _material;
        private IMaterialWarehouseItemRepository _materialWarehouseItem;
        private IProductWarehouseItemRepository _productWarehouseItem;
        private ICustomOrderItemRepository _customOrderItem;
        private IStandardOrderItemRepository _standardOrderItem;
        private IFileItemRepository _fileItem;
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_erpContext);
                }
                return _user;
            }
        }

        public IClientRepository Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new ClientRepository(_erpContext);
                }
                return _client;
            }
        }

        public IOrderRepository Order
        {
            get
            {
                if (_order == null)
                {
                    _order = new OrderRepository(_erpContext);
                }
                return _order;
            }
        }
        public IStandardProductRepository StandardProduct
        {
            get
            {
                if (_standardProduct == null)
                {
                    _standardProduct = new StandardProductRepository(_erpContext);
                }
                return _standardProduct;
            }
        }

        public ICustomProductRepository CustomProduct
        {
            get
            {
                if (_customProduct == null)
                {
                    _customProduct = new CustomProductRepository(_erpContext);
                }
                return _customProduct;
            }
        }

        public IStandardProductCategoryRepository StandardProductCategory
        {
            get
            {
                if (_standardProductCategory == null)
                {
                    _standardProductCategory = new StandardProductCategoryRepository(_erpContext);
                }
                return _standardProductCategory;
            }
        }

        public IMaterialRepository Material
        {
            get
            {
                if (_material == null)
                {
                    _material = new MaterialRepository(_erpContext);
                }
                return _material;
            }
        }

        public IMaterialWarehouseItemRepository MaterialWarehouseItem
        {
            get
            {
                if (_materialWarehouseItem == null)
                {
                    _materialWarehouseItem = new MaterialWarehouseItemRepository(_erpContext);
                }
                return _materialWarehouseItem;
            }
        }

        public IProductWarehouseItemRepository ProductWarehouseItem
        {
            get
            {
                if (_productWarehouseItem == null)
                {
                    _productWarehouseItem = new ProductWarehouseItemRepository(_erpContext);
                }
                return _productWarehouseItem;
            }
        }

        public ICustomOrderItemRepository CustomOrderItem
        {
            get
            {
                if (_customOrderItem == null)
                {
                    _customOrderItem = new CustomOrderItemRepository(_erpContext);
                }
                return _customOrderItem;
            }
        }

        public IStandardOrderItemRepository StandardOrderItem
        {
            get
            {
                if (_standardOrderItem == null)
                {
                    _standardOrderItem = new StandardOrderItemRepository(_erpContext);
                }
                return _standardOrderItem;
            }
        }

        public IFileItemRepository FileItem
        {
            get
            {
                if (_fileItem == null)
                {
                    _fileItem = new FileItemRepository(_erpContext);
                }
                return _fileItem;
            }
        }

        public RepositoryWrapper(ERPContext erpContext)
        {
            _erpContext = erpContext;
        }

        public async Task SaveAsync()
        {
            await _erpContext.SaveChangesAsync();
        }
    }
}