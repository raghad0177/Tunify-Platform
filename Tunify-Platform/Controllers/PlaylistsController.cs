using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylists _playlists;
        public PlaylistsController(IPlaylists context)
        {
            _playlists = context;
        }
        // GET: api/Playlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlists>>> Getplaylists()
        {
            return await _playlists.GetAllPlaylists();
        }
        // GET: api/Playlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Playlists>> GetPlaylists(int id)
        {
            return await _playlists.GetPlaylistByIdAsync(id);
        }
        // PUT: api/Playlists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylists(int id, Playlists playlists)
        {
           var updated= await _playlists.UpdatePlaylist(id, playlists);
            return Ok(updated);
        }
        // POST: api/Playlists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Playlists>> PostPlaylists(Playlists playlists)
        {
            var created = await _playlists.CreatePlaylistAsync(playlists);
            return Ok(created);
        }
        // DELETE: api/Playlists/5
        [HttpDelete("{id}")]
        public async Task DeletePlaylists(int id)
        {
           await _playlists.DeletePlaylistAsync(id);
        }
    }
}
