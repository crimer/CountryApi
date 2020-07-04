using Microsoft.Extensions.DependencyInjection;

namespace CountryApi.Extentions
{
    public static class Swagger
    {
        public static void UseSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();
        }
    }
}
