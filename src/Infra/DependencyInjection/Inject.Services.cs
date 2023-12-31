using Child.Growth.src.Services.Implementations;
using Child.Growth.src.Services.Interfaces;

namespace Child.Growth.src.Infra.DependencyInjection
{
    public class InjectServices
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IChildrenService, ChildrenService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPatientConsultationService, PatientConsultationService>();
            services.AddScoped<IResponsibleService, ResponsibleService>();
        }
    }
}