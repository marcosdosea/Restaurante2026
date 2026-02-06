using Core;
using Core.Service;
using Service;
using Microsoft.EntityFrameworkCore;

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

            builder.Services.AddTransient<IRestauranteService, RestauranteService>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddTransient<ITiporestauranteService, TiporestauranteService>();
            builder.Services.AddTransient<IGrupocardapioService, GrupocardapioService>();
            builder.Services.AddTransient<IFuncaoFuncionarioService, FuncaoFuncionarioService>();
            builder.Services.AddTransient<IItemcardapioService, ItemcardapioService>();
            builder.Services.AddTransient<IMesaService, MesaService>();
            builder.Services.AddTransient<IFormapagamentoService, FormapagamentoService>();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
