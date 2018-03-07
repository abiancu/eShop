using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AlejandroElectronics.Models;

namespace AlejandroElectronics
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
            services.AddSession();
            services.AddMvc();
            services.AddDbContext<AlejandroTestContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
            sqlOptions => sqlOptions.MigrationsAssembly(this.GetType().Assembly.FullName)));
            //UseInMemoryDatabase("Identities"));

            services.AddAntiforgery(); //for security!
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AlejandroTestContext>()
                .AddDefaultTokenProviders(); 

            //setting up connectioString
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            
            // SERVICE TO READ THE secretAPI key
            services.AddTransient<SendGrid.SendGridClient>((x) =>
            {
                return new SendGrid.SendGridClient(Configuration["myKey"]);
            });

            

          
            //Adding Trasient services for BRAINTREE
            services.AddTransient<Braintree.BraintreeGateway>((x) =>
            {
                return new Braintree.BraintreeGateway(
                    Configuration["braintree.environment"],
                    Configuration["braintree.merchantid"],
                    Configuration["braintree.publickey"],
                    Configuration["braintree.privatekey"]
                );
                   
            });

            // Adding Transient service for SMARTYSTREETS
            services.AddTransient<SmartyStreets.USStreetApi.Client>((x) =>
            {
                var client = new SmartyStreets.ClientBuilder(
                     Configuration["smartystreets.authid"],
                     Configuration["smartystreets.authtoken"])
                         .BuildUsStreetApiClient();
                return client;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AlejandroTestContext context)
         {
           
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            DbInitializer.Initialize(context);
        }
    }
}
