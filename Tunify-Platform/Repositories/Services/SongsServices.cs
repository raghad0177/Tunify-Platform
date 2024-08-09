using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class SongsServices : ISongs
    {
        private readonly TunifyDbContext _context;
        public SongsServices(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<Songs> CreateSong(Songs song)
        {
           await _context.songs.AddAsync(song);
           await _context.SaveChangesAsync();
           return song;
        }
        public async Task DeleteSong(int id)
        {
            var deleted = await _context.songs.FindAsync(id);
             _context.songs.Remove(deleted);
            await _context.SaveChangesAsync();
            
        }
        public async Task<List<Songs>> GetAllSongs()
        {
           var allSongs= await _context.songs.ToListAsync();
           return allSongs;
        }
        public async Task<Songs> GetSongById(int id)
        {
            //var oneSong = _context.songs.Where(x => x.Equals(id));
            var oneSong = await _context.songs.FindAsync(id);
            return oneSong;
        }
        public async Task<Songs> UpdateSong(int id, Songs song)
        {
            var oldSong = await _context.songs.FindAsync(id);
            oldSong = song;
            await _context.SaveChangesAsync();
            return oldSong;
        }
    }
}
