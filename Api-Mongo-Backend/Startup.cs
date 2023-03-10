using Api_Mongo_Backend.Models;
using Api_Mongo_Backend.Services;
using ApiMongo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Mongo_Backend
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

            services.Configure<ProductoSettings>(Configuration.GetSection(nameof(ProductoSettings)));
            services.AddSingleton<IProductoSettings>(d => d.GetRequiredService<IOptions<ProductoSettings>>().Value);

            services.Configure<VentaSettings>(Configuration.GetSection(nameof(VentaSettings)));
            services.AddSingleton<IVentaSettings>(d => d.GetRequiredService<IOptions<VentaSettings>>().Value);

            services.Configure<ClienteSettings>(Configuration.GetSection(nameof(ClienteSettings)));
            services.AddSingleton<IClienteSettings>(d => d.GetRequiredService<IOptions<ClienteSettings>>().Value);

            services.AddSingleton<ClienteServicios>();
            services.AddSingleton<ProductoServicios>();
            services.AddSingleton<VentaServicios>();

            services.AddControllers();
            
            
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
