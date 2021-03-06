using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestorauntMenu.Data;
using RestorauntMenu.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using RestorauntMenu.Data.Repository;


namespace RestorauntMenu
{
    public class Startup
    {
        private readonly IConfigurationRoot _confString;

        public Startup(IWebHostEnvironment hostEnv)
        {   
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IDishes, DishRepository>();
            services.AddMvc(option => option.EnableEndpointRouting = false);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

			using var scope = app.ApplicationServices.CreateScope();
			AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
			DbObject.Initialize(context);

		}
    }
}
