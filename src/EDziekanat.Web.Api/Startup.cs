using EDziekanat.Application;
using EDziekanat.Application.DeansOffices;
using EDziekanat.Application.Departments;
using EDziekanat.Application.Messages;
using EDziekanat.Application.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using EDziekanat.Web.Core.ActionFilters;
using EDziekanat.Web.Core.Extensions;
using Swashbuckle.AspNetCore.Filters;
using EDziekanat.Web.Api.Hubs;

namespace EDziekanat.Web.Api
{
    public class Startup
    {


        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDbContext(_configuration);
            services.ConfigureAuthentication();
            services.ConfigureJwtTokenAuth(_configuration);
            services.ConfigureCors(_configuration);
            services.ConfigureDependencyInjection();
            services.ConfigureEDziekanatApplication();
            services.ConfigureSmtp(_configuration);

          

            services.AddControllers(setup => { setup.Filters.AddService<UnitOfWorkActionFilter>(); })
                .AddNewtonsoftJson();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo {Title = "EDziekanat API", Version = "v1"});
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IDeansOfficesService, DeansOfficeService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IMessageService, MessageService>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: _configuration["App:CorsOriginPolicyName"],
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:8080")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod()
                                      .AllowCredentials();
                                  });
            });

            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EDziekanat API V1");
            });

            app.UseCors(_configuration["App:CorsOriginPolicyName"]);
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chatHub");
            });
        }
    }
}