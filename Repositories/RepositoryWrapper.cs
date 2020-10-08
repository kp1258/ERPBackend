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

        public RepositoryWrapper(ERPContext erpContext)
        {
            _erpContext = erpContext;
        }

        public void Save()
        {
            _erpContext.SaveChanges();
        }
    }
}