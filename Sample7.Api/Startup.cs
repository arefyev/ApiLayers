using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sample7.Biz;
using Sample7.Data;
using Sample7.Models.Common;
using System.IO;
using System.Text.Json;

namespace Sample7.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
       WebHost.CreateDefaultBuilder(args)
              .ConfigureAppConfiguration((hostingContext, config) =>
              {
                  config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
              })
              .UseStartup<Startup>();

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                                 builder => builder
                         .SetIsOriginAllowed(_ => true)
                         .AllowAnyHeader().AllowAnyMethod().AllowCredentials()
                        );
            });

            services.AddCors().AddMvc().AddNewtonsoftJson()
            .AddMvcOptions(options => { })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Задание 7 API", Version = "v1" });

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "Sample7Api.xml");
                c.IncludeXmlComments(filePath);
            });

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));


            services
                    .AddSingleton<IUsersRepository, UsersRepository>()
                    .AddSingleton<IProductsRepository, ProductsRepository>()
                    .AddSingleton<ICartsRepository, CartsRepository>()

                    .AddScoped<IUserService, UserService>()
                    .AddScoped<IProductsService, ProductsService>()
                    .AddScoped<ICartsService, CartsService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
