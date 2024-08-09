using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class PlaylistsServices : IPlaylists
    {
        private readonly TunifyDbContext _context;
        public PlaylistsServices(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<Playlists> CreatePlaylistAsync(Playlists playlist)
        {
            await _context.playlists.AddAsync(playlist);
            await _context.SaveChangesAsync();
            return playlist;
        }
        public async Task DeletePlaylistAsync(int playlistId)
        {
            var deleted = await _context.playlists.FindAsync(playlistId);
            _context.playlists.Remove(deleted);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Playlists>> GetAllPlaylists()
        {
            var allplaylists = await _context.playlists.ToListAsync();
            return allplaylists;
        }

        public async Task<Playlists> GetPlaylistByIdAsync(int playlistId)
        {

            //var oneSong = _context.songs.Where(x => x.Equals(id));
            var onePlaylist = await _context.playlists.FindAsync(playlistId);
            return onePlaylist;
        }

        public async Task<Playlists> UpdatePlaylist(int playlistId, Playlists playlist)
        {
            var oldPlaylist = await _context.playlists.FindAsync(playlistId);
            oldPlaylist = playlist;
            await _context.SaveChangesAsync();
            return oldPlaylist;
        }
    }
}
