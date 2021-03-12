using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Common.Extensions
{
    public static class ApiServicesExtensions
    {
        public static void AddExtentions(this IServiceCollection services, IConfiguration configuration)
        {
            var infos = new ApiInfos { ApiDescription = $"{Resources.ApiInfos.Name} - {Resources.ApiInfos.ApiName}" };

            services.SetApiVersion();
            services.SetSwagger(infos);
        }

        internal static void AddExtensions(this IApplicationBuilder app, IApiVersionDescriptionProvider versionProvider)
        {
            app.SetSwagger(versionProvider);
        }
    }
}
