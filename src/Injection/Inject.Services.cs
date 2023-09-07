using Child.Growth.src.Services;
using Child.Growth.src.Services.Interfaces;

namespace Child.Growth.src.Injection
{
    public class InjectServices
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IUsersService, UsersService>();
        }
    }
}