using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OxiFin.Bootstrap;
using OxiFin.Common.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using JwtAuth;
using JwtAuth.Config;

namespace OxiFin.Api
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
            
            DIBootstrap.RegisterAppTypes(services);

            services.AddSwaggerDocument(document =>
            {
                document.Title = "OxiFin API";
                document.DocumentName = "swagger";
            }).AddOpenApiDocument(document => document.DocumentName = "OxiFin API");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            //app.UseHsts();            
        }
    }
}
