using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using NeSever.Common.Utils.Security;
using NeSever.WebUI.Services;
using System;
using System.Text.Json.Serialization;

namespace NeSever.WebUI
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
            services.AddHttpClient<IUyelikApiService, UyelikApiService>();
            services.AddHttpClient<ISayfaApiService, SayfaApiService>();
            services.AddHttpClient<IUrunApiService, UrunApiService>();
            services.AddHttpClient<IDataAktarimApiService, DataAktarimApiService>();
            services.AddHttpClient<IKatalogApiService, KatalogApiService>();
            services.AddHttpClient<IProgramApiService, ProgramApiService>();
            services.AddHttpClient<ISistemApiService, SistemApiService>();
            services.AddHttpClient<ISatisApiService, SatisApiService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddHttpContextAccessor();

            services.AddRazorPages().AddRazorRuntimeCompilation();

            //services.AddDistributedMemoryCache();
            //services.AddMemoryCache();

            services.Configure<NeSeverSettings>(Configuration.GetSection("NeSeverSettings"));

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            
            string sessionTimeout = Configuration["NeSeverSettings:SessionTimeout"]?.ToString();
            if (string.IsNullOrEmpty(sessionTimeout))
            {
                services.AddSession(options =>
                {
                    //options.Cookie.Name = ".NeSever.Session";
                    options.IdleTimeout = TimeSpan.FromMinutes(60);
                    //options.Cookie.IsEssential = true;
                });
            }
            else
            {
                services.AddSession(options =>
                {
                    //options.Cookie.Name = ".NeSever.Session";
                    options.IdleTimeout = TimeSpan.FromMinutes(Convert.ToInt32(sessionTimeout));
                    //options.Cookie.IsEssential = true;
                });
            }

            services.AddMvc().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            });

            services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
                options.MaxRequestBodySize = long.MaxValue;
            });

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
                options.Limits.MaxRequestBodySize = long.MaxValue;               
            });

            services.AddDataProtection();

            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //.AddCookie(options =>
            //{
            //    options.Cookie.Expiration = TimeSpan.FromHours(5);
            //});
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {          
                app.UseExceptionHandler("/Home/Hata");
            }

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Home/SayfaBulunamadi";
                    await next();
                }
            });

            string dataServerDirectory = Configuration["NeSeverSettings:DataServerDirectory"]?.ToString();
            if (!string.IsNullOrEmpty(dataServerDirectory))
            {
                app.UseFileServer(new FileServerOptions
                {
                    FileProvider = new PhysicalFileProvider(dataServerDirectory),
                    RequestPath = new PathString("/Data"),
                    EnableDirectoryBrowsing = false
                });
            }

            string uploadServerDirectory = Configuration["NeSeverSettings:UploadsServerDirectory"]?.ToString();
            if (!string.IsNullOrEmpty(uploadServerDirectory))
            {
                app.UseFileServer(new FileServerOptions
                {
                    FileProvider = new PhysicalFileProvider(uploadServerDirectory),
                    RequestPath = new PathString("/Uploads"),
                    EnableDirectoryBrowsing = false
                });
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                ForwardedHeaders.XForwardedProto
            });

            app.UseStaticFiles();           

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
