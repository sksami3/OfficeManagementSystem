using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OSA.Core.Interface;
using OSA.Core.Repository;
using OSA.Infructructure.Services;
using OSA.Infructructure.Services.Helpers;
using OSA.Infructructure.Services.Services.Implementations;
using OSA.Infructructure.Services.Services.Interfaces;
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
            services.AddDbContext<OfficeAttendenceSystemDbContext>();
            //services.AddDbContext<OfficeAttendenceSystemDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OfficeAttendenceSystemDbContext")));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllers();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAttachmentService, AttachmentService>();
            services.AddTransient<IAttendanceService, AttendanceService>();
            //services.AddControllers().AddNewtonsoftJson();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

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

            //services.AddControllers();

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

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
