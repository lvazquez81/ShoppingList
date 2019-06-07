using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShippingListLib;
using ShoppingListApi.Data;
using ShoppingListApi.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace ShoppingListApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //services.AddDbContext<ShoppingListDbContext>(opt =>
            //    opt.UseInMemoryDatabase("ShoppngListDb"));

            services.AddDbContext<ShoppingListDbContext>(
                opts => opts.UseSqlServer(Configuration["ConnectionString:Default"]));

            services.AddScoped<IShoppingListService, DbShoppingListService>();

            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "Shopping List", Version = "v1" });
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Shopping List V1");
                //c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Shopping}/{action=Index}");
            });
        }
    }
}
