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
using Welp.Web.Helpers;
using Microsoft.Extensions.Options;
using Sakura.AspNetCore.Mvc;

namespace Welp.Web
{ 
    public class AccountSetting
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }


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

            services.AddOptions();
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.Configure<List<AccountSetting>>(Configuration.GetSection("DefaultAccounts"));


            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            services.AddTransient<IToolsService, ToolsService>();
            services.AddTransient<IUserManagerService, UserManagerService>();

            services.AddTransient<ServerContext, ServerContext>();

            services.AddBootstrapPagerGenerator(options =>
            {
                options.ConfigureDefault();
            });


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
                AppId = Configuration.GetValue<string>("FacebookData:AppId"),
                AppSecret = Configuration.GetValue<string>("FacebookData:AppSecret")
            });
            app.UseGoogleAuthentication(new GoogleOptions()
            {
                ClientId = Configuration.GetValue<string>("GoogleData:ClientId"),
                ClientSecret = Configuration.GetValue<string>("GoogleData:ClientSecret"),
            });

            app.UseTwitterAuthentication(new TwitterOptions()
            {
                ConsumerKey = Configuration.GetValue<string>("TwitterData:ConsumerKey"),
                ConsumerSecret = Configuration.GetValue<string>("TwitterData:ConsumerSecret"),
            });

            app.UseMicrosoftAccountAuthentication(new MicrosoftAccountOptions()
            {
                ClientId = Configuration.GetValue<string>("MicrosoftData:ClientId"),
                ClientSecret = Configuration.GetValue<string>("MicrosoftData:ClientSecret"),
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
            if (!await roleManager.RoleExistsAsync("welper"))
                await roleManager.CreateAsync(new IdentityRole("welper"));
            if (!await roleManager.RoleExistsAsync("client"))
                await roleManager.CreateAsync(new IdentityRole("client"));
            if (!await roleManager.RoleExistsAsync("manager"))
                await roleManager.CreateAsync(new IdentityRole("manager"));

            var userManager = app.ApplicationServices.GetService<UserManager<ApplicationUser>>();

            var defaultAccounts = app.ApplicationServices.GetRequiredService<IOptions<List<AccountSetting>>>().Value;

            foreach (var account in defaultAccounts)
            {
                var user = await userManager.FindByEmailAsync(account.UserName);
                if (user == null)
                {
                    user = new ApplicationUser() { UserName = account.UserName, Email = account.UserName };
                    var x = await userManager.CreateAsync(user, account.Password);
                    if (!await userManager.IsInRoleAsync(user, account.Role))
                        await userManager.AddToRoleAsync(user, account.Role);
                }
            }

          

        }

        public void SeedData(IApplicationBuilder app)
        {
            var _context = app.ApplicationServices.GetService<ApplicationDbContext>();
            _context.SeedAll();
        }
    }
}
