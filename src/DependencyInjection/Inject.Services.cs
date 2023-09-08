using Child.Growth.src.Services;
using Child.Growth.src.Services.Interfaces;

namespace Child.Growth.src.DependencyInjection
{
    public class InjectServices
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}