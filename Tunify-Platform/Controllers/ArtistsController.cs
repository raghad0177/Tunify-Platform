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
    public class ArtistsController : ControllerBase
    {
        private readonly IArtists _artists;
        public ArtistsController(IArtists context)
        {
            _artists = context;
        }
        // GET: api/Artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artists>>> Getartists()
        {
            return await _artists.GetAllArtist();
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artists>> GetArtist(int id)
        {
            return await _artists.GetArtistById(id);
        }
        // PUT: api/Artists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtists(int id, Artists artists)
        {
           var updated = await _artists.UpdateArtist(id,artists);
            return Ok(updated);
        }
        // POST: api/Artists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artists>> PostArtists(Artists artists)
        {
           return await _artists.CreateArtist(artists);
        }
        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public async Task DeleteArtists(int id)
        {
             await _artists.DeleteArtist(id);
        }
    }
}
