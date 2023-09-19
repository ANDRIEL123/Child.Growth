using System.Text;
using Child.Growth.src.Infra.Data;
using Child.Growth.src.Infra.Data.UnitOfWork;
using Child.Growth.src.Infra.DependencyInjection;
using Child.Growth.src.Repositories.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

            // Adiciona filtro de exceção
            services.AddControllers(options =>
            {
                options.Filters.Add(new CustomExceptionFilterAttribute());
            });

            // Registra o repositório no Container de Injeção de Dependência
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Registra o Unit of Work no Container de Injeção de Dependência
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Habita cors
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            // Injeta os serviços
            InjectServices.AddServices(services);

            // Adiciona autenticação JWT Bearer
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:SecretKey"]))
                    };
                });

            // Configuração do banco de dados
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

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            // Configurações de autenticação e autorização
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}