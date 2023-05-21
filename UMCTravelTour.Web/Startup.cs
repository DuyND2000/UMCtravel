using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UMCTravelTour.Core;
using UMCTravelTour.Core.CustomIdentity;
using UMCTravelTour.DAL.Infrastructures;
using UMCTravelTour.DAL.IRepositories;
using UMCTravelTour.DAL.Repositories;
using UMCTravelTour.Service.Bookings;
using UMCTravelTour.Service.Comments;
using UMCTravelTour.Service.Customers;
using UMCTravelTour.Service.EmailTemplates;
using UMCTravelTour.Service.Hotels;
using UMCTravelTour.Service.Locations;
using UMCTravelTour.Service.Restaurants;
using UMCTravelTour.Service.Rooms;
using UMCTravelTour.Service.Tours;
using UMCTravelTour.ViewModel.AutoMappers;
using UMCTravelTour.Web.Services;
using System;
using System.Threading.Tasks;

namespace UMCTravelTour.Web
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
            services.AddDbContext<UMCTravelContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<DreamTourUser>(options => {
                options.SignIn.RequireConfirmedAccount = true;
            }).AddRoles<DreamTourRole>().AddEntityFrameworkStores<UMCTravelContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);

                options.LoginPath = "/Home/Index/";
                options.LogoutPath = "/";
                options.SlidingExpiration = true;
                options.AccessDeniedPath = "/UserAuth/AccessDenied";
            });

            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<DbInitializer, DbInitializer>();

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<ITourService, TourService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ITourDesignService, TourDesignService>();
            services.AddScoped<IEmailTemplateSerice, EmailTemplateSerice>();
            services.AddScoped<ICommentService, CommentService>();

            //Email gui thong qua mailkit and mimekit
            services.AddOptions();
            var mailsettings = Configuration.GetSection("MailSettings");
            services.Configure<MailSettingService>(mailsettings);
            services.AddTransient<EmailTemplateSerice>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UMCTravelContext context, UserManager<DreamTourUser> userManager)
        {
            if (env.IsDevelopment())
            {
                new DbInitializer(context).SeedData();
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                #region PreventIdentityDefaultPath
                endpoints.MapGet("/Identity/Account/Login", context => Task.Factory.StartNew(() => context.Response.Redirect("/", true, true)));
                endpoints.MapGet("/Identity/Account/Logout", context => Task.Factory.StartNew(() => context.Response.Redirect("/", true, true)));
                endpoints.MapGet("/Identity/Account/Manage", context => Task.Factory.StartNew(() => context.Response.Redirect("/", true, true)));
                endpoints.MapGet("/Identity/Account/Manage/ChangePassword", context => Task.Factory.StartNew(() => context.Response.Redirect("/", true, true)));
                endpoints.MapGet("/Identity/Account/ForgotPassword", context => Task.Factory.StartNew(() => context.Response.Redirect("/", true, true)));
                endpoints.MapGet("/Identity/Account/ConfirmEmail", context => Task.Factory.StartNew(() => context.Response.Redirect("/", true, true)));
                endpoints.MapGet("/Identity/Account/ConfirmEmailChange", context => Task.Factory.StartNew(() => context.Response.Redirect("/", true, true)));
                #endregion

                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

           
        }
    }
}
