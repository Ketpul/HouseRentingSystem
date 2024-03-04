using HouseRentingSystem.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection sevices)
        {
            return sevices;
        }
        
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection sevices, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            sevices.AddDbContext<HouseRentingDbContext>(options =>
                options.UseSqlServer(connectionString));

            sevices.AddDatabaseDeveloperPageExceptionFilter();

            return sevices;
        }
        
        public static IServiceCollection AddApplicationIdentity(this IServiceCollection sevices, IConfiguration config)
        {
            sevices
                .AddDefaultIdentity<IdentityUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                 })
                .AddEntityFrameworkStores<HouseRentingDbContext>();

            return sevices;
        }


    }
}
