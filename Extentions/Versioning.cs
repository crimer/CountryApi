using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;


namespace CountryApi.Extentions
{
    public static class Versioning
    {
        public static void UseVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                // tell user what api version supported in Headers
                opt.ReportApiVersions = true;
                // Specify the default API Version
                opt.DefaultApiVersion = new ApiVersion(1, 1);
                // If the client hasn't specified the API version in the request, use the default API version number 
                opt.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                opt.ReportApiVersions = true;
                // clients request the specific version using the X-Version Header
                opt.ApiVersionReader = ApiVersionReader.Combine(
                    new HeaderApiVersionReader("X-Version"),
                    new QueryStringApiVersionReader("v"));
            });
            services.AddVersionedApiExplorer(
               options =>
               {
                   options.GroupNameFormat = "'v'VVV";

                   // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                   // can also be used to control the format of the API version in route templates
                   options.SubstituteApiVersionInUrl = true;
               });
        }
    }
}
