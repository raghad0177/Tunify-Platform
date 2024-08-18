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
            // Get the connection string settings  
            string ConnectionStringVar = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<TunifyDbContext>(optionsX => optionsX.UseSqlServer(ConnectionStringVar));
            builder.Services.AddScoped<IArtists, ArtistsServices>();
            builder.Services.AddScoped<IPlaylists, PlaylistsServices>();
            builder.Services.AddScoped<ISongs, SongsServices>(); 
            builder.Services.AddScoped<IUsers, UsersServices>();
            var app = builder.Build();
            app.MapControllers();
            app.MapGet("/", () => "Hello World!");
            app.Run();
        }
    }
}