using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface ISongs
    {
        Task<List<Songs>> GetAllSongs();
        Task<Songs> GetSongById(int id);
        Task<Songs> CreateSong(Songs song);
        Task<Songs> UpdateSong(int id,Songs song);
        Task DeleteSong(int id);
        Task<Songs> AddSongToArtist(int artistId, int songId);
        Task<List<Songs>> GetSongsForPlaylist(int playlistID);
        Task<List<Songs>> GetSongsForArtists(int ArtistsId);
    }
}
