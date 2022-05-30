using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGames.WebApi.Data;
using VideoGames.WebApi.Models;

namespace VideoGames.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        private readonly VideoGameDbContext _context;
        public VideoGamesController(VideoGameDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task <IEnumerable<VideoGame>> Get()
        {
            return await _context.VideoGames.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VideoGame), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var game = await _context.VideoGames.SingleOrDefaultAsync(x => x.Id == id);
            return game == null ? NotFound() : Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> Create(VideoGame game)
        {
            await _context.VideoGames.AddAsync(game);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { Id = game.Id }, game);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update (Guid id, VideoGame game)
        {
            if(id == game.Id) return BadRequest();
            _context.Entry(game).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var gameToDelete = await _context.VideoGames.SingleOrDefaultAsync(x => x.Id == id);
            if(gameToDelete == null) return NotFound();
            _context.VideoGames.Remove(gameToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
