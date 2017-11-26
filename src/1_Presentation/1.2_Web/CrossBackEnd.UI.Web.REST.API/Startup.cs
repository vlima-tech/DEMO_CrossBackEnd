
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using CrossBackEnd.GeoLocation.Infra.Server.IoC;
using AutoMapper;

namespace CrossBackEnd.UI.Web.REST.API
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
            services.AddMvc();
            services.AddAutoMapper();

            /*
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));
            */

            services.AddGeoLocation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes => 
            {
                /*
                routes.MapRoute(
                    name: "default",
                    template: "api/{controller=Index}/{action=index}/{id?}"
                );
                */

                routes.MapRoute(
                    name: "default",
                    template: "api/{context=country}/{controller=Country}/{action=get}/{id?}"
                );
            });
        }
    }
}
