using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Belatrix.WebApi;
using Belatrix.WebApi.Identity.Data;
using Belatrix.WebApi.Models;
using Belatrix.WebApi.Profiles;
using Belatrix.WebApi.Repository;
using Belatrix.WebApi.Repository.Postgresql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

[assembly: ApiConventionType(typeof(BelatrixApiConventions))]
namespace Belatrix.WebApi
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
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CustomerProfile>();
            });

            services.AddAutoMapper(typeof(CustomerProfile).Assembly);

            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddEntityFrameworkNpgsql()
               .AddDbContextPool<BelatrixDbContext>(
                opt => opt.UseNpgsql(Configuration.GetConnectionString("postgresql"),
                b => b.MigrationsAssembly("Belatrix.WebApi")))
               .BuildServiceProvider();

            services.AddEntityFrameworkNpgsql()
               .AddDbContextPool<ApplicationDbContext>(
                opt => opt.UseNpgsql(Configuration.GetConnectionString("postgresql"),
                b => b.MigrationsAssembly("Belatrix.WebApi")))
               .BuildServiceProvider();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IRepository<Customer>, Repository<Customer>>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Belatrix API",
                    Version = "v1"
                });
                c.CustomSchemaIds(x => x.FullName);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            SeedData.Initialize(app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope().ServiceProvider);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", 
                    "Belatrix Api v1");
            });
        }
    }
}
