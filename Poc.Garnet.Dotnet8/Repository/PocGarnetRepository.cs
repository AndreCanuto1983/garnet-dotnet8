using Garnet.client;
using Poc.Garnet.Dotnet8.Interface;
using Poc.Garnet.Dotnet8.Map;

namespace Poc.Garnet.Dotnet8.Repository
{
    public class PocGarnetRepository(ILogger<PocGarnetRepository> logger) : IPocGarnetRepository
    {
        private readonly ILogger<PocGarnetRepository> _logger = logger;

        public async Task<string> GetAsync(string key, CancellationToken cancellationToken)
        {
            try
            {
                using GarnetClient garnetClient = DataMap.GetConnectionWithGarnet();

                await garnetClient.ConnectAsync(cancellationToken);

                _logger.LogInformation("[PocGarnetRepository][GetAsync][Key]: {Key}", key);

                string response = await garnetClient.StringGetAsync(key, cancellationToken);

                _logger.LogInformation("[PocGarnetRepository][GetAsync][Response]: {Resp}", response);

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[PocGarnetRepository][GetAsync][Exception]: {Ex}", ex.Message);
                throw;
            }
        }

        public async Task InsertAsync(string key, string data, CancellationToken cancellationToken)
        {
            try
            {
                using GarnetClient garnetClient = DataMap.GetConnectionWithGarnet();

                await garnetClient.ConnectAsync(cancellationToken);

                _logger.LogInformation("[PocGarnetRepository][InsertAsync][Key]: {Key}", key);
                _logger.LogInformation("[PocGarnetRepository][InsertAsync][Data]: {Data}", data);

                await garnetClient.StringSetAsync(key, data, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[PocGarnetRepository][InsertAsync][Exception]: {Ex}", ex.Message);
                throw;
            }
        }

        public async Task DeleteAsync(string key, CancellationToken cancellationToken)
        {
            try
            {
                using GarnetClient garnetClient = DataMap.GetConnectionWithGarnet();

                await garnetClient.ConnectAsync(cancellationToken);

                _logger.LogInformation("[PocGarnetRepository][DeleteAsync][Key]: {Key}", key);

                await garnetClient.KeyDeleteAsync(key, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[PocGarnetRepository][DeleteAsync][Exception]: {Ex}", ex.Message);
                throw;
            }
        }
    }
}