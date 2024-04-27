using System.Reflection;

namespace Poc.Garnet.Dotnet8.Settings
{
    public static class SwaggerSettings
    {
        public static void AddSwaggerSettings(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }
    }
}