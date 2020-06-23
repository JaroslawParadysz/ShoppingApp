using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShoppingApp.API.Extensions;
using ShoppingApp.Application.Configuration.Commands;
using ShoppingApp.Application.Configuration.UnitOfWork;
using ShoppingApp.Application.SeedWork;
using ShoppingApp.Domain.Orders;
using ShoppingApp.Domain.Products;
using ShoppingApp.Domain.SeedWork;
using ShoppingApp.Infrastructure.SqlServer.Database;
using ShoppingApp.Infrastructure.SqlServer.Domain;
using ShoppingApp.Infrastructure.SqlServer.Domain.Order;
using ShoppingApp.Infrastructure.SqlServer.Domain.Product;
using ShoppingApp.Infrastructure.SqlServer.SeedWork;

namespace ShoppingApp.API
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
            services.AddDbContext<ShoppingAppContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"),
                    options => options.EnableRetryOnFailure());
            });
            services.AddControllers();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISqlConnectionFactory>(x => new SqlConnectionFactory(Configuration.GetConnectionString("DefaultConnectionString")));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddCQRS();
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
