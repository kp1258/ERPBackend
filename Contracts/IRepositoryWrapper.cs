namespace ERPBackend.Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IClientRepository Client { get; }
        void Save();
    }
}