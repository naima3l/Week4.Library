using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week4.Library.Core.BusinessLayer;
using Week4.Library.Core.Interfaces;
using Week4.Library.EF;
using Week4.Library.EF.Repositories;

namespace Week4.Library.AppClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //DI
            services.AddTransient<IBusinessLayer, MainBusinessLayer>(); //bl

            services.AddTransient<IBookRepository, EFBookRepository>();

            services.AddTransient<IPrestitoRepository, EFPrestitoRepository>();

            services.AddDbContext<LibraryContext>(options =>
            {
                options.UseSqlServer(@"Server = (localdb)\mssqllocaldb;
                Database = LibraryDb; Trusted_Connection = True;");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
