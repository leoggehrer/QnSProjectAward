//@QnSCodeCopy
//MdStart
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace QnSProjectAward.WebApi
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            BeginConfigureServices(services);
            services.AddControllers();
            services.AddResponseCompression();
            EndConfigureServices(services);
        }
        partial void BeginConfigureServices(IServiceCollection services);
        partial void EndConfigureServices(IServiceCollection services);

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            BeginConfigure(app, env);

            // Transfer the application settings to the logic.
            Logic.Modules.Configuration.AppSettings.SetConfiguration(Configuration);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseResponseCompression();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            EndConfigure(app, env);
        }
        partial void BeginConfigure(IApplicationBuilder app, IWebHostEnvironment env);
        partial void EndConfigure(IApplicationBuilder app, IWebHostEnvironment env);
    }
}
//MdEnd
