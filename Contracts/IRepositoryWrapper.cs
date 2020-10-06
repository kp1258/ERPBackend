namespace ERPBackend.Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        void Save();
    }
}