using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Child.Growth.src.Data;
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

            // Configuração do banco de dados (se estiver usando Entity Framework Core)
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Outros serviços e injeções de dependência

            // Registro de serviços personalizados
            // services.AddScoped<IMeuServico, MeuServico>();

            // Registro de serviços para autenticação e autorização (se necessário)
            // services.AddAuthentication();
            // services.AddAuthorization();
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