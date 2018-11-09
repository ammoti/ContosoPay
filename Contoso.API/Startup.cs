using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Contoso.Data;
using Contoso.Data.Abstract;
using Contoso.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Contoso.API.Core;
using Swashbuckle.AspNetCore.Swagger;
using Contoso.API.ViewModels.Mappings;
using static Contoso.Data.Abstract.IRepositories;

namespace Contoso.API
{

    public class Startup
    {
        private static string _applicationPath = string.Empty;
        string sqlConnectionString = string.Empty;
        bool useInMemoryProvider = false;
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            _applicationPath = env.WebRootPath;

            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true).AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string sqlConnectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                useInMemoryProvider = bool.Parse(Configuration["AppSettings:InMemoryProvider"]);
            }
            catch
            { }

            services.AddDbContext<ContosoContext>(options =>
            {
                switch (useInMemoryProvider)
                {
                    case true:
                        options.UseInMemoryDatabase();
                        break;
                    default:
                        options.UseSqlServer(sqlConnectionString, b => b.MigrationsAssembly("Contoso.API"));
                        break;
                }
            });


            //Repositories
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddScoped<IOperationRepository, OperationRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();

            //AutoMapper
            AutoMapperConfiguration.Configure();

            services.AddCors();

            services.AddMvc().AddJsonOptions(opts =>
            {
                opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Contoso",
                    Description = "Contoso .NET Core",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Contoso Pay", Email = "vahap.yigit@gmail.com.tr", Url = "www.vahapyigit.com.tr" }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        context.Response.AddApplicationError(error.Error.Message);
                        await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                    }
                });
            });

            app.UseStaticFiles();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}