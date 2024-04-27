namespace Poc.Garnet.Dotnet8.Interface
{
    public interface IPocGarnetRepository
    {
        Task<string> GetAsync(string key, CancellationToken cancellationToken);
        Task InsertAsync(string key, string data, CancellationToken cancellationToken);
        Task DeleteAsync(string key, CancellationToken cancellationToken);
    }
}
