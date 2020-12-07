using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Neo4jClient;
using Microsoft.Extensions.Options;
using Server.Models;
using Server.Persistence;
using Server.Services;

namespace Server
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
            services.Configure<GraphDbSettings>(
                Configuration.GetSection(nameof(GraphDbSettings)));

            services.AddSingleton<IGraphDbSettings>(sp =>
                sp.GetRequiredService<IOptions<GraphDbSettings>>().Value);

            services.Configure<SportsShopDBSettings>(
                Configuration.GetSection(nameof(SportsShopDBSettings)));

            services.AddSingleton<ISportsShopDBSettings>(sp =>
                sp.GetRequiredService<IOptions<SportsShopDBSettings>>().Value);

            services.AddSingleton<SportsShopDBService>();

            services.AddCors(options =>
            {
                options.AddPolicy(
                  "CorsPolicy",
                  builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddSingleton<GraphDbContext>();

            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson();
            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddRazorPages().AddNewtonsoftJson();
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

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
