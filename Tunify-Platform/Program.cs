using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Tunify_Platform.Data;
using Tunify_Platform.Repositories.Interfaces;
using Tunify_Platform.Repositories.Services;

namespace Tunify_Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Tunify API",
                    Version = "v1",
                    Description = "API for managing playlists, songs, and artists in the Tunify Platform"
                });
            });
            // Get the connection string settings  
            string ConnectionStringVar = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<TunifyDbContext>(optionsX => optionsX.UseSqlServer(ConnectionStringVar));
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
           .AddEntityFrameworkStores<TunifyDbContext>();          
            builder.Services.AddScoped<IArtists, ArtistsServices>();
            builder.Services.AddScoped<IPlaylists, PlaylistsServices>();
            builder.Services.AddScoped<ISongs, SongsServices>();
            builder.Services.AddScoped<IUsers, UsersServices>();

            builder.Services.AddScoped<IAccounts, IdentityAccountService>();
            var app = builder.Build();
            app.UseAuthentication();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Tunify API",
                    Version = "v1", 
                    Description = "API for managing playlists, songs, and artists in the Tunify Platform"
                });
            });
           
            app.UseSwagger(
             options =>
             {
                 options.RouteTemplate = "api/{documentName}/swagger.json";
             }
             );
            //=====
            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");
            //=====
           
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Tunify API v1");
                options.RoutePrefix = "";
            });
            app.MapControllers();
            app.MapGet("/", () => "Hello World!");
            app.Run();
        }
    }
}