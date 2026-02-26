using Core;
using Core.Service;
using Service;
using Microsoft.EntityFrameworkCore;
using RestauranteWeb.Areas.Identity.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace RestauranteWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString("RestauranteConnection");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Conexão com o banco de dados não foi configurada corretamente.");
            }
            builder.Services.AddDbContext<RestauranteContext>(
                options => options.UseMySQL(connectionString));

            var connectionIdentityString = builder.Configuration.GetConnectionString("IdentityContextConnection");
            if (string.IsNullOrEmpty(connectionIdentityString))
            {
                throw new InvalidOperationException("Conexão com o banco de dados de usuários não foi configurada corretamente.");
            }
            builder.Services.AddDbContext<IdentityContext>(
                options => options.UseMySQL(connectionIdentityString));

            builder.Services.AddDefaultIdentity<UsuarioIdentity>(options =>
            {
                //signIn settings
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                //password settings
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;

                //default user settings
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;

                //lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            }).AddEntityFrameworkStores<IdentityContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.Cookie.Name = "RestauranteWebAuthCookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/Identity/Account/Login";

                //returnUrlParameter
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

            builder.Services.AddTransient<IRestauranteService, RestauranteService>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddTransient<ITiporestauranteService, TiporestauranteService>();
            builder.Services.AddTransient<IGrupocardapioService, GrupocardapioService>();
            builder.Services.AddTransient<IFuncaoFuncionarioService, FuncaoFuncionarioService>();
            builder.Services.AddTransient<IItemcardapioService, ItemcardapioService>();
            builder.Services.AddTransient<IMesaService, MesaService>();
            builder.Services.AddTransient<IFormapagamentoService, FormapagamentoService>();
            builder.Services.AddTransient<IFuncionarioService, FuncionarioService>();
            builder.Services.AddTransient<IAtendimentoService, AtendimentoService>();
            builder.Services.AddTransient<IPedidoService, PedidoService>();
            builder.Services.AddTransient<IPagamentoService, PagamentoService>();

            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseSession();

            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
