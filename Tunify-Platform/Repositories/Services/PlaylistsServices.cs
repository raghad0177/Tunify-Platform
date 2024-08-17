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
        public async Task<Playlists> AddSongToPlaylist(int playlistId, int songId)
        {
            var playlistSong = new PlaylistSongs
            {
                PlaylistsId = playlistId,
                SongsId = songId
            };
            _context.playlistSongs.Add(playlistSong);
            await _context.SaveChangesAsync();
            var playlist = _context.playlists.FirstOrDefault(p => p.PlaylistsId == playlistId);
            return playlist;
        }
         public async Task<List<Songs>> GetSongsForPlaylist(int playlistID)
        {
            var playlistsSongsVar = await _context.playlistSongs
                .Where(pl => pl.PlaylistsId == playlistID)
                .Select(pl => pl.Songs)
                .ToListAsync();
            return playlistsSongsVar;
        }
    }
}