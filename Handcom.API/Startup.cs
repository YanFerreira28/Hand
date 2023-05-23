using Handcom.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Handcom.Infra.Repository;
using Handcom.Domain.Interfaces.Service;
using Handcom.Application.Services;

namespace Handcom.API
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
            //repositories


            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository>(c=> new UserRepository(new Infra.Data.HandcomContext()));
            services.AddScoped<IProductRepository>(c => new ProductRepository(new Infra.Data.HandcomContext()));
            services.AddScoped<ISupplierRepository>(c => new SupplierRepository(new Infra.Data.HandcomContext()));
            services.AddScoped<ICategoryRepository>(c => new CategoryRepository(new Infra.Data.HandcomContext()));

            //services
            services.AddScoped(typeof(IBaseService<>),  typeof(BaseService<>));
            services.AddScoped<IUserService>(c => new UserService(new BaseRepository<Domain.Entities.Users>(new Infra.Data.HandcomContext())));
            services.AddScoped<IProductService>(c => new ProductService(new BaseRepository<Domain.Entities.Products>(new Infra.Data.HandcomContext())));
            services.AddScoped<ISupplierService>(c => new SupplierService(new BaseRepository<Domain.Entities.Supplier>(new Infra.Data.HandcomContext())));
            services.AddScoped<ICategoryService>(c => new CategoryService(new BaseRepository<Domain.Entities.Category>(new Infra.Data.HandcomContext())));


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Handcom.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Handcom.API v1"));
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
