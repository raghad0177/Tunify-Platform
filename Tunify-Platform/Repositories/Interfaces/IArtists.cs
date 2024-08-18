using Microsoft.AspNetCore.Mvc;
using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IArtists
    {
        Task<Artists> CreateArtist(Artists artist);
        Task<List<Artists>> GetAllArtist();
        Task<Artists> GetArtistById(int artistId);
        Task<Artists> UpdateArtist(int id, Artists artist);
        Task DeleteArtist(int id);
    }
}
