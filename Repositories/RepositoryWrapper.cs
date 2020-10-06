using ERPBackend.Contracts;
using ERPBackend.Entities;

namespace ERPBackend.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ERPContext _erpContext;
        private IUserRepository _user;

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