using JwtAuth;
using JwtAuth.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OxiFin.Bootstrap;
using OxiFin.Common.Middlewares;
using SwaggerLib;

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

            services.SetSwagger("Auth.API");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.SetSwagger();
            app.UseRouting();
            app.UseCors(action =>
              action
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .AllowAnyOrigin());
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseGuardMiddleware();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute().RequireAuthorization();
            });
        }
    }
}
