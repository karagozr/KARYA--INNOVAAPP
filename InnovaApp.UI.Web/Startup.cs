using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnovaApp.DataAccess.Context;
using InnovaApp.UI.Web.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InnovaApp.UI.Web
{
    public class Startup
    {

        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddDbContext<NetsisDonemContext>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromHours(12);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });


            //services.AddDbContext<InnovaApp.DataAccess.Context.InnovaContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("InnovaConnection")));
        }

        //private NetsisDonemContext ResolveDbContext(IServiceProvider provider, IHostingEnvironment hostingEnv)
        //{
        //    // ...
        //    string connectionString = Configuration.GetConnectionString("DefaultConnection");

        //    string SOME_DB_IDENTIFYER = httpContextAccessor.HttpContext.User.Claims
        //        .Where(c => c.Type == "[SOME_DB_IDENTIFYER]").Select(c => c.Value).FirstOrDefault();
        //    if (!string.IsNullOrWhiteSpace(SOME_DB_IDENTIFYER))
        //    {
        //        connectionString = connectionString.Replace("[DB_NAME]", $"{SOME_DB_IDENTIFYER}Db");
        //    }

        //    var dbContext = new DefaultDbContextFactory().CreateDbContext(connectionString);

        //    // ....
        //    return dbContext;
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.CustomStaticFiles();
            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "adminProducts",
                //    template: "admin/products",
                //    defaults: new { controller = "Admin", Action = "ProductList" }
                //        );
                //routes.MapRoute(
                //   name: "adminProducts",
                //   template: "admin/products/{id?}",
                //   defaults: new { controller = "Admin", Action = "EditProduct" }
                //       );
                //routes.MapRoute(
                //    name: "adminCategories",
                //    template: "admin/categories",
                //    defaults: new { controller = "Admin", Action = "CategoryList" }
                //        );
                //routes.MapRoute(
                //   name: "adminCategories",
                //   template: "admin/categories/{id?}",
                //   defaults: new { controller = "Admin", Action = "EditCategory" }
                //       );
                //routes.MapRoute(
                //    name: "products",
                //    template: "products/{category?}",
                //    defaults: new { controller = "shop", Action = "List" }
                //        );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                        );
            });
        }
    }
}
