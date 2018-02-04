using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Extreme_Test.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Extreme_Test.Services.Interfaces;
using Extreme_Test.Services.Services;

namespace Extreme_Test
{
    public class Startup
    {
        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
        {
            public ApplicationContext CreateDbContext(string[] args)
            {
                var builder = new DbContextOptionsBuilder<ApplicationContext>();

                string connectionString = "Server=.\\SQLEXPRESS;Database=ExtremeTestVacancies;Trusted_Connection=True;";

                builder.UseSqlServer(connectionString,
               opt => opt.UseRowNumberForPaging());

                return new ApplicationContext(builder.Options);
            }
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = "Server=.\\SQLEXPRESS;Database=ExtremeTestVacancies;Trusted_Connection=True;";//TODO: to config
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString,
               opt => opt.UseRowNumberForPaging()));

            services.AddMvc();
            services.AddTransient<IVacanciesDataHelper, VacanciesDataHelper>();
            services.AddTransient<IVacancyService, VacancyService>();
            services.AddTransient<IWebApiClient, WebApiClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
