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
            services.AddControllers().AddNewtonsoftJson();


            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.WithOrigins("https://localhost:4200"));
            });
            services.AddCors(o => o.AddPolicy("AllowOrigin", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));



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

            app.UseCors(options => options.AllowAnyOrigin());

            app.UseCors(options => options.WithOrigins("https://localhost:4200"));

            app.UseCors("AllowOrigin");

        }
    }
}
