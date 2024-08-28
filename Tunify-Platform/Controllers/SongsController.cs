using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongs _songs;
        public SongsController(ISongs context)
        {
            _songs = context;
        }
        // GET: api/Songs
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Songs>>> Getsongs()
        {
            return await _songs.GetAllSongs();
        }
        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Songs>> GetSongs(int id)
        {
            return await _songs.GetSongById(id);
        }
        // PUT: api/Songs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // user has the claim update , admin has the claim update 
        [Authorize(Policy = "RequireAdminRole")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongs(int id, Songs songs)
        {
           var updated = await _songs.UpdateSong(id, songs);
            return Ok(updated);
        }
        // POST: api/Songs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Songs>> PostSongs(Songs songs)
        {
            var created = await _songs.CreateSong(songs);
            return Ok(created);
        }
        // DELETE: api/Songs/5        
        [HttpDelete("{id}")]
        public async Task DeleteSongs(int id)
        {
          await _songs.DeleteSong(id);
        }
        // Lab 13 
        [HttpPost("artists/{artistId}/songs/{songId}")]
        public async Task<IActionResult> AddSongToArtist(int artistId, int songId)
        {
            var result = await _songs.AddSongToArtist(artistId, songId);
            return Ok(result);
        }
        [HttpGet("{id}/allSongs/playlists")]
        public async Task<ActionResult<List<Songs>>> GetSongsForPlaylist(int playlistId)
        {
            var Song = await _songs.GetSongsForPlaylist(playlistId);
            return Ok(Song);
        }
        [HttpGet("{id}/allSongs/artists")]
        public async Task<ActionResult<List<Songs>>> GetSongsForArtists(int Artistsid)
        {
            var Song = await _songs.GetSongsForArtists(Artistsid);
            return Ok(Song);
        }
    }
}
