using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Welp.Web.Data;
using Welp.Web.Models;
using Welp.Web.Services;
using Microsoft.AspNetCore.Identity;

namespace Welp.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>( options =>
            {
                options.Password.RequiredLength = Configuration.GetValue<int>("PasswordOptions:RequiredLength", 8);
                options.Password.RequireDigit = Configuration.GetValue<bool>("PasswordOptions:RequireDigit", true);
                options.Password.RequireLowercase = Configuration.GetValue<bool>("PasswordOptions:RequireLowercase", true);
                options.Password.RequireNonAlphanumeric = Configuration.GetValue<bool>("PasswordOptions:RequireNonAlphanumeric", true);
                options.Password.RequireUppercase = Configuration.GetValue<bool>("PasswordOptions:RequireUppercase", true);
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseFacebookAuthentication(new FacebookOptions()
            {
                AppId = "test",
                AppSecret = "test"
            });

            app.UseGoogleAuthentication(new GoogleOptions()
            {
                ClientId = "test",
                ClientSecret = "test"
            });

            app.UseTwitterAuthentication(new TwitterOptions()
            {
                ConsumerKey= "test",
                ConsumerSecret = "test"
            });
        

            app.UseIdentity();

            SeedUsersAndRolesAsync(app).Wait();
            SeedData(app);

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public async Task SeedUsersAndRolesAsync(IApplicationBuilder app)
        {
            var _context = app.ApplicationServices.GetService<ApplicationDbContext>();
            

            var roleManager = app.ApplicationServices.GetService<RoleManager<IdentityRole>>();            
            if (!await roleManager.RoleExistsAsync("admin"))
                await roleManager.CreateAsync(new IdentityRole("admin"));
            if (!await roleManager.RoleExistsAsync("tech"))
                await roleManager.CreateAsync(new IdentityRole("tech"));
            if (!await roleManager.RoleExistsAsync("client"))
                await roleManager.CreateAsync(new IdentityRole("client"));
            if (!await roleManager.RoleExistsAsync("manager"))
                await roleManager.CreateAsync(new IdentityRole("manager"));

            var userManager = app.ApplicationServices.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByEmailAsync("rumbu@rumbu.ro");
            if (user == null)
            {
                user = new ApplicationUser() { UserName = "rumbu@rumbu.ro",  Email = "rumbu@rumbu.ro" };
                var x = await userManager.CreateAsync(user, "changeme");                
            }

            if (!await userManager.IsInRoleAsync(user, "admin"))
                await userManager.AddToRoleAsync(user, "admin");


            user = await userManager.FindByEmailAsync("mihai.marincea@gmail.com");
            if (user == null)
            {
                user = new ApplicationUser() { UserName = "mihai.marincea@gmail.com", Email = "mihai.marincea@gmail.com" };
                var x = await userManager.CreateAsync(user, "changeme");
            }

            if (!await userManager.IsInRoleAsync(user, "admin"))
                await userManager.AddToRoleAsync(user, "admin");

        }

        public void SeedData(IApplicationBuilder app)
        {
            var _context = app.ApplicationServices.GetService<ApplicationDbContext>();
            _context.SeedAll();
        }
    }
}
