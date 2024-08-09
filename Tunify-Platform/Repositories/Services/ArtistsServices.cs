using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class ArtistsServices:IArtists
    {
        private readonly TunifyDbContext _context;
        public ArtistsServices(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<Artists> CreateArtist(Artists artist)
        {
            await _context.artists.AddAsync(artist);
            await _context.SaveChangesAsync();
            return artist;
        }
        public async Task DeleteArtist(int id)
        {
            var deleted = await _context.artists.FindAsync(id);
            _context.artists.Remove(deleted);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Artists>> GetAllArtist()
        {
            var allartists = await _context.artists.ToListAsync();
            return allartists;
        }
        public async Task<Artists> GetArtistById(int artistId)
        {
            //var oneSong = _context.songs.Where(x => x.Equals(id));
            var oneSong = await _context.artists.FindAsync(artistId);
            return oneSong;
        }
        public async Task<Artists> UpdateArtist(int id, Artists artist)
        {
            var oldSong = await _context.artists.FindAsync(id);
            oldSong = artist;
            await _context.SaveChangesAsync();
            return oldSong;
        }
    }
}
