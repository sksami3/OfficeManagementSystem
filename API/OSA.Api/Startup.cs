using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OSA.Core.Interface;
using OSA.Infructructure.Services;
using OSA.Infructure.Context.OASDbContext;

namespace OSA.Api
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
            //services.AddDbContext<OfficeAttendenceSystemDbContext>(options => options.(...));
            services.AddDbContext<OfficeAttendenceSystemDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OfficeAttendenceSystemDbContext")));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllers();

            services.AddTransient<IDepartmentRepository, DepartmentService>();
            services.AddTransient<IEmployeeRepository, EmployeeService>();
            services.AddControllers().AddNewtonsoftJson();

            //CROS
            services.AddCors(options =>
            {
                options.AddPolicy("foo",
                builder =>
                {
                    // Not a permanent solution, but just trying to isolate the problem
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddControllers();

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            //services.AddDbContextPool<OfficeAttendenceSystemDbContext>(options =>
            // options.UseLazyLoadingProxies()
            // .UseSqlServer(Configuration.GetConnectionString("OfficeAttendenceSystemDbContext")));
             //.UseSqlServer("OfficeAttendenceSystemDbContext"));

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

            //CORS
            app.UseHttpsRedirection();

            // Use the CORS policy
            app.UseCors("foo");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

    }
}
