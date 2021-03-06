using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Hosting;
using Shop.Models;

namespace Shop
{
    public class Startup //startup 
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        // called by .net core automatically 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(); // we have to add support to MVC 
            // adding our own custom service
            // NB the addscope method means that an instance will be created in each request and
            // it will remain active for the whole request! - needed to work with database!
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();

            //controllers create responses in MVC

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
            //tells the app what environment it should run in
            // IApplicationBuilder - tells we want the application to run in HTTPS
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // allows us to display error messages - disable before you deploy the app live
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // will automatically search for directory wwwroot - enables images and js
            app.UseRouting();

            app.UseEndpoints(endpoints => // enable MVC to respond to request
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    ); // allows our app to route through the request and return a response
            });
        }

    }
}
