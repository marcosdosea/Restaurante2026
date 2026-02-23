
using BibliotecaAPI.Filter;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestauranteWeb.Areas.Identity.Data;
using Service;

namespace RestauranteAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container with Exception handling.
            builder.Services.AddControllers(options => options.Filters.Add(new HttpResponseExceptionFilter()));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<IRestauranteService, RestauranteService>();
            builder.Services.AddTransient<ITiporestauranteService, TiporestauranteService>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


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

            builder.Services.AddIdentityApiEndpoints<UsuarioIdentity>(
                options =>
                {
                    // SignIn settings
                    options.SignIn.RequireConfirmedAccount = false;
                    options.SignIn.RequireConfirmedEmail = false;
                    options.SignIn.RequireConfirmedPhoneNumber = false;

                    // Password settings
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;

                    // Default User settings.
                    options.User.AllowedUserNameCharacters =
                            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    //options.User.RequireUniqueEmail = true;

                    // Default Lockout settings
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.AllowedForNewUsers = true;
                }).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();


            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
