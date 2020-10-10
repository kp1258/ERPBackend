namespace ERPBackend.Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IClientRepository Client { get; }
        IOrderRepository Order { get; }
        IStandardProductRepository StandardProduct { get; }
        ICustomProductRepository CustomProduct { get; }
        IStandardProductCategoryRepository StandardProductCategory { get; }
        IMaterialRepository Material { get; }
        void Save();
    }
}