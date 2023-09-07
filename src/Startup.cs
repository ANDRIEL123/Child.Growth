using Child.Growth.src.Data;
using Child.Growth.src.Data.UnitOfWork;
using Child.Growth.src.Injection;
using Child.Growth.src.Repositories.Base;
using Child.Growth.src.Repositories.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace Child.Growth
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
            // Configurações gerais

            // Adicione serviços do ASP.NET Core MVC
            services.AddControllersWithViews();

            // Registra o repositório no Container de Injeção de Dependência
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Registra o Unit of Work no Container de Injeção de Dependência
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Injeta os serviços
            InjectServices.AddServices(services);

            // Configuração do banco de dados (se estiver usando Entity Framework Core)
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Configurações de autenticação e autorização (se necessário)
            // app.UseAuthentication();
            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}