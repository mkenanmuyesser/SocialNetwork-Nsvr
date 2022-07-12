using AutoMapper;
using HappyFit.Data.Context.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NeServer.Business.DataAktarim;
using NeServer.Business.Katalog;
using NeServer.Business.Program;
using NeServer.Business.Sayfa;
using NeServer.Business.Sistem;
using NeServer.Business.Urun;
using NeServer.Business.Uyelik;
using NeSever.Api.Mapper;
using NeSever.Common.Infra.DataLayer;
using NeSever.Common.Utils.Security.Token;
using NeSever.Data.Context;
using NeSever.Data.DataService;
using NeSever.Data.DataService.DataAktarim;
using NeSever.Data.DataService.Katalog;
using NeSever.Data.DataService.Program;
using NeSever.Data.DataService.Sayfa;
using NeSever.Data.DataService.Sistem;
using NeSever.Data.DataService.Uyelik;
using System;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Caching.Distributed;

namespace NeSever.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration["connectionStrings:NeSeverCoreProjectDBConnectionString"];
            services.AddDbContext<NeSeverCoreProjectDBContext>(c => c.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(120)), ServiceLifetime.Scoped);
            services.AddTransient<IRepository, EntityFrameworkRepository>();
            services.AddTransient<IReadOnlyRepository, EntityFrameworkReadOnlyRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDbFactory, DbFactory>();
            services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            services.AddLogging();

            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IProgramBusiness, ProgramBusiness>();
            services.AddScoped<IProgramDataService, ProgramDataService>();
            services.AddScoped<IUyelikBusiness, UyelikBusiness>();
            services.AddScoped<IUyelikDataService, UyelikDataService>();
            services.AddScoped<ISayfaBusiness, SayfaBusiness>();
            services.AddScoped<ISayfaDataService, SayfaDataService>();
            services.AddScoped<IUrunBusiness, UrunBusiness>();
            services.AddScoped<IUrunDataService, UrunDataService>();
            services.AddScoped<IKatalogBusiness, KatalogBusiness>();
            services.AddScoped<IKatalogDataService, KatalogDataService>();
            services.AddScoped<IDataAktarimBusiness, DataAktarimBusiness>();
            services.AddScoped<IDataAktarimService, DataAktarimService>();
            services.AddScoped<ISistemBusiness, SistemBusiness>();
            services.AddScoped<ISistemDataService, SistemDataService>();
            services.AddScoped<ISatisBusiness, SatisBusiness>();
            services.AddScoped<ISatisDataService, SatisDataService>();

            services.AddDistributedMemoryCache();

            services.AddLogging();

            services.AddControllers();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            bool cacheIsActive = Convert.ToBoolean(Configuration["AppSettings:CacheIsActive"]);
            if (cacheIsActive)
            {
                string cacheType = Configuration["AppSettings:CacheType"]?.ToString();
                if (cacheType != null && cacheType == "Redis")
                {
                    string cacheConfig = Configuration["AppSettings:CacheConfig"]?.ToString();
                    services.AddStackExchangeRedisCache(action =>
                    {
                        action.Configuration = cacheConfig;
                    });
                }
            }

            services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(jwtbeareroptions =>
            {
                jwtbeareroptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    IssuerSigningKey = SignHandler.GetSecurityKey(tokenOptions.SecurityKey),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
