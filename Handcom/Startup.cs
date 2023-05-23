using Handcom.Application.Services;
using Handcom.Domain.Interfaces.Repository;
using Handcom.Domain.Interfaces.Service;
using Handcom.Infra.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Handcom
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
            services.AddPaging(options => {
                options.ViewName = "Bootstrap4";
                options.PageParameterName = "pageindex";
            });


            //repositories


            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository>(c => new UserRepository(new Infra.Data.HandcomContext()));
            services.AddScoped<IProductRepository>(c => new ProductRepository(new Infra.Data.HandcomContext()));
            services.AddScoped<ISupplierRepository>(c => new SupplierRepository(new Infra.Data.HandcomContext()));
            services.AddScoped<ICategoryRepository>(c => new CategoryRepository(new Infra.Data.HandcomContext()));
            services.AddScoped<ISessionRepository>(c => new SessionRepository(new Infra.Data.HandcomContext()));

            //services
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<IUserService>(c => new UserService(new BaseRepository<Domain.Entities.Users>(new Infra.Data.HandcomContext())));
            services.AddScoped<IProductService>(c => new ProductService(new BaseRepository<Domain.Entities.Products>(new Infra.Data.HandcomContext())));
            services.AddScoped<ISupplierService>(c => new SupplierService(new BaseRepository<Domain.Entities.Supplier>(new Infra.Data.HandcomContext())));
            services.AddScoped<ICategoryService>(c => new CategoryService(new BaseRepository<Domain.Entities.Category>(new Infra.Data.HandcomContext())));
            services.AddScoped<ISessionService>(c => new SessionService(new BaseRepository<Domain.Entities.Session>(new Infra.Data.HandcomContext())));


            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
