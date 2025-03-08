using FirstAPI.Mappings;
using FirstAPI.Serviece;
using FirstAPPWithAPI.Data;
using Microsoft.OpenApi.Models;
using FirstAPI.Data.IdentityMangement;
using Microsoft.AspNetCore.Identity;

namespace FirstAPPWithAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

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
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            //builder.Services.AddAutoMapper(typeof(MappingForMovieDto));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppdbContext>();

            builder.Services.AddCors();
            builder.Configuration.AddUserSecrets<Program>();

            var ConnectionString = builder.Configuration.GetConnectionString("constr");
            builder.Services.AddDbContext<AppdbContext>(options =>
                options.UseSqlServer(ConnectionString));
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IGenresServiece, GenresServiece>();
            builder.Services.AddScoped<IMovieServiece, MovieServiece>();
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.MapOpenApi();
            }
            app.UseHttpsRedirection();
            app.UseCors(op => op.AllowAnyHeader().AllowAnyOrigin());//cors
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
