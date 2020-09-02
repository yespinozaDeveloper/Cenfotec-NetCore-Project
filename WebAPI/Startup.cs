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
using Microsoft.OpenApi.Models;
using WebAPI.Infrastructure.Data.Models;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI
{
    public class Startup
    {
        public IWebHostEnvironment ApplicationEnvironment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            ApplicationEnvironment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var applicationSettings = new ApplicationSettings();
            var appSettingsSection = Configuration.GetSection("AppSettings");
            appSettingsSection.Bind(applicationSettings);

            var var1 = Environment.GetEnvironmentVariable("AppSettings__Variable");
            if (!string.IsNullOrEmpty(var1))
            {
                applicationSettings.Variable = var1;
            }

            services.AddSingleton(applicationSettings);
            services.AddDbContext<TMP_DEMOContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultDataBase")));


            services.AddScoped<ProductRepository>();
            services.AddScoped<CategoryRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<OrderRepository>();
            services.AddScoped<OrderDetailRepository>();
            services.AddScoped<ReviewRepository>();

            services.AddCors(options => options.AddDefaultPolicy(builder => {
                // Fluent API
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Net Core API", Version = "1.0.0", Contact = new OpenApiContact() { Name ="yespinozaDeveloper", Email="yespinoza@tecnosys.net"} });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Net Core API");
            });

            app.UseCors();
            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
