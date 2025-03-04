using FirstAPI.Serviece;
using FirstAPPWithAPI.Data;
//using FirstAPPWithAPI.MiddleWares;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Formatting.Compact;

namespace FirstAPPWithAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "DemoAPI",
                    Contact = new OpenApiContact
                    {
                        Name = "Belal",
                        Email = "belalelmansy796@gmail.com",
                    },
                    TermsOfService = new Uri("https://www.google.com"),
                    Description = "MyAPIs",
                    License = new OpenApiLicense
                    {
                        Name = "Mylicense",
                        Url = new Uri("https://www.google.com")
                    },
                });
            });
            builder.Services.AddCors();
            builder.Configuration.AddUserSecrets<Program>();

            var ConnectionString = builder.Configuration.GetConnectionString("constr");
            builder.Services.AddDbContext<AppdbContext>(options =>
                options.UseSqlServer(ConnectionString));
            builder.Services.AddLogging(cfg => cfg.AddDebug());

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped< IGenresServiece, GenresServiece>();
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.MapOpenApi();
            }
            //app.UseMiddleware<ProfilingMiddleWare>();
            app.UseHttpsRedirection();
            app.UseCors(op => op.AllowAnyHeader().AllowAnyOrigin());//cors
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
