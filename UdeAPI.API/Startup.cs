using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UdeAPI.Core.Repositories;
using UdeAPI.Core.Services;
using UdeAPI.Core.UnitOfWorks;
using UdeAPI.Data;
using UdeAPI.Data.Repositories;
using UdeAPI.Data.UnitOfWorks;
using UdeAPI.Service.Services;
using AutoMapper;
using UdeAPI.API.Filters;
using Microsoft.AspNetCore.Diagnostics;
using UdeAPI.API.DTOs;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using UdeAPI.API.Extensions;

namespace UdeAPI.API
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
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<NotFoundFilter>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(), o =>
                {
                    o.MigrationsAssembly("UdeAPI.Data");
                });
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddControllers();

            //////Örnek ValidationFilterı bütün controllerlarda çalışmasını istiyoruz attribute olarak tek tek eklemek istemiyoruz. Yapılacak olan
            //services.AddControllers(o =>
            //{
            //    o.Filters.Add(new ValidationFilter());
            //});

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomException();

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
