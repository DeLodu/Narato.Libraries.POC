using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Narato.Correlations;
using Narato.ExecutionTimingMiddleware;
using Narato.ResponseMiddleware;
using Newtonsoft.Json.Serialization;
using Swashbuckle.Swagger.Model;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Narato.Libraries.POC.Application.Common;
using Narato.Libraries.POC.Application.UseCases;
using Narato.Libraries.POC.Application.UseCases.Books;
using Narato.Libraries.POC.DataProvider.Contexts;
using Narato.Libraries.POC.DataProvider.DataProviders;
using Narato.Libraries.POC.Domain.Models.Books;
using Newtonsoft.Json;

namespace Narato.Libraries.POC.API
{
    public class Startup
    {
        
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc(
            //Add this filter globally so every request runs this filter to recored execution time
                config =>
                {
                    config.AddResponseFilters();
                })
                .AddJsonOptions(x =>
                {
                    x.SerializerSettings.ContractResolver =
                     new CamelCasePropertyNamesContractResolver();
                    x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    x.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                }
            );

            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration["DATABASECONFIGURATION:CONNECTIONSTRING"]));

            // Dataproviders
            services.AddTransient<IBookDataProvider, BookDataProvider>();
            services.AddTransient<IAuthorDataProvider, AuthorDataProvider>();

            // Books
            services.AddTransient<IUseCases<CreateBookRequest, CreateBookResponse>, CreateBookUseCase>();
            services.AddTransient<IUseCases<DeleteBookRequest, DeleteBookResponse>, DeleteBookUseCase>();
            services.AddTransient<IUseCases<FindBooksRequest, FindBooksResponse>, FindBooksUseCase>();
            services.AddTransient<IUseCases<GetBookByIDRequest, GetBookByIDResponse>, GetBookByIDUseCase>();
            services.AddTransient<IUseCases<UpdateBookRequest, UpdateBookResponse>, UpdateBookUseCase>();

            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Contact = new Contact { Name = "Narato NV" },
                    Description = "Narato Libraries Narato.Libraries.POC.API API",
                    Version = "v1",
                    Title = "Narato.Libraries.POC.API"
                });
                //options.OperationFilter<ProducesConsumesFilter>();

                var xmlPaths = GetXmlCommentsPaths();
                foreach (var entry in xmlPaths)
                {
                    try
                    {
                        options.IncludeXmlComments(entry);
                    }
                    catch (Exception)
                    {
                    }
                }
            });

            services.AddCorrelations();
            services.AddResponseMiddleware();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler();
            app.UseCorrelations();
            app.UseExecutionTiming();

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUi();

            app.UseMvc();
        }

        private List<string> GetXmlCommentsPaths()
        {
            var app = PlatformServices.Default.Application;
            var files = new List<string>()
                        {
                            "Narato.Libraries.POC.API.xml"
                        };

            List<string> paths = new List<string>();
            foreach (var file in files)
            {
                paths.Add(Path.Combine(app.ApplicationBasePath, file));
            }

            return paths;
        }
    }
}
