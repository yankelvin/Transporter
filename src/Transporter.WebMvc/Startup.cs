using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Transporter.Administration.Application.Mappers;
using Transporter.Administration.Application.Service;
using Transporter.Administration.Data;
using Transporter.Administration.Domain.Interfaces;
using Transporter.Transport.Application.Mappers;
using Transporter.Transport.Application.Service;
using Transporter.Transport.Data;
using Transporter.Transport.Domain.Interfaces;

namespace Transporter.WebMvc
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
            var connectionString = Configuration.GetConnectionString("TransporterContext");
            services.AddDbContext<AdministrationContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<TransportContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPassengerRepository, PassengerRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<ITransportRecordRepository, TransportRecordRepository>();

            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<ITransportAppService, TransportAppService>();

            services.AddAutoMapper(typeof(AdministrationMapper));
            services.AddAutoMapper(typeof(TransportMapper));

            services.AddControllersWithViews();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var administrationContext = serviceScope.ServiceProvider.GetRequiredService<AdministrationContext>();
                var transportContext = serviceScope.ServiceProvider.GetRequiredService<TransportContext>();

                administrationContext.Database.Migrate();
                transportContext.Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
