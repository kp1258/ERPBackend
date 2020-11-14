using System.Text;
using ERPBackend.Contracts;
using ERPBackend.Repositories;
using ERPBackend.Services;
using ERPBackend.Services.ModelsServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ERPBackend.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(
                options =>
                {
                    options.AddPolicy("CorsPolicy",
                        builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                    );
                }

            );
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomOrderItemService, CustomOrderItemService>();
            services.AddScoped<ICustomProductService, CustomProductService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IStandardProductService, StandardProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClientService, ClientService>();

            services.AddScoped<IBlobStorageService, BlobStorageService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }

        public static void ConfigureJwtAuthentication(this IServiceCollection services)
        {

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = "http://localhost:5000",
                    ValidAudience = "http://localhost:5000",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
                };
            });
        }
    }
}