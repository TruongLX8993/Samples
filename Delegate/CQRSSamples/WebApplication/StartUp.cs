using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication.Application.Behaviors;
using WebApplication.Application.Interfaces;
using WebApplication.Application.Validator;
using WebApplication.Infrastructures;
using WebApplication.Infrastructures.Data.NhibernateRepository;
using WebApplication.Infrastructures.Data.Read;

namespace WebApplication
{
    public class Startup
    {
        private const string DbConnection =
            @"Data source=E:\Sample-Projects\Samples\Delegate\CQRSSamples\studentmgr.sqlite;";


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            services.AddValidatorFactory(Assembly.GetExecutingAssembly());
            services.AddDataLayerService(DbConnection);
        }

        public void ConfigDataServices(IServiceCollection services)
        {
            services.AddSingleton<IReadDbConnectionFactory>(new SqliteReadDbConnectionFactory(DbConnection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
                endpoints.MapControllers();
            });
        }
    }
}