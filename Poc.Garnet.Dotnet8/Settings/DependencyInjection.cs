using Poc.Garnet.Dotnet8.Interface;
using Poc.Garnet.Dotnet8.Repository;

namespace Poc.Garnet.Dotnet8.Settings
{
    public static class DependencyInjection
    {
        public static void AddIoc(this IServiceCollection services)
        {
            services
                .AddTransient<IPocGarnetRepository, PocGarnetRepository>();
        }
    }
}
