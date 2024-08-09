using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IPlaylists
    {
        Task<List<Playlists>> GetAllPlaylists();
        Task<Playlists> GetPlaylistByIdAsync(int playlistId);
        Task<Playlists> CreatePlaylistAsync(Playlists playlist);
        Task<Playlists> UpdatePlaylist(int playlistId, Playlists playlist);
        Task DeletePlaylistAsync(int playlistId);
    }
}
