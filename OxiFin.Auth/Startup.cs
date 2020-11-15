using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Extensions;
using JwtAuth;
using JwtAuth.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxiFin.Bootstrap;
using OxiFin.Common.Middlewares;

namespace OxiFin.Auth
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = int.MaxValue;
                options.ValueLengthLimit = int.MaxValue;
            });

            JwtTokenDefinitions.LoadFromConfiguration(Configuration);
            services.ConfigureJwtAuthentication();
            services.ConfigureJwtAuthorization();
            
            services.AddCors();

            services.AddControllers();
            services.AddOpenApiDocument();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpClient();

            DIBootstrap.RegisterAuthTypes(services);

            services.AddSwaggerDocument(document =>
            {
                document.Title = "OxiFin Auth API";
                document.DocumentName = "swagger";
            }).AddOpenApiDocument(document => document.DocumentName = "OxiFin Auth API");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
