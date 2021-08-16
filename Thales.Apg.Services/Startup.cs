using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Thales.Apg.Business;
using Thales.Apg.Business.Interfaces;
using Thales.Apg.Data.Interfaces;
using Thales.Apg.Data.Services.External;

namespace Thales.Apg.Services
{
    public class Startup
    {
        private IConfiguration appSettings { get; }

        public Startup(IConfiguration _appSettings)
        {
            appSettings = _appSettings;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpClient("Employees", cfg =>
            {
                cfg.BaseAddress = new Uri(appSettings["Services:Employees"]);
            });

            services.AddTransient<IServiceEmployees, ServiceEmployees>();
            services.AddTransient<IAppEmployee, AppEmployee>();
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
                endpoints.MapControllers();
            });
        }
    }
}
