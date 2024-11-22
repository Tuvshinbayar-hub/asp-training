using DesignAPI_DotNet8.Data;
using DesignAPI_DotNet8.Models.Colors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorGroupController : ControllerBase
    {
        private readonly DataContext _context;

        public ColorGroupController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetColorGroups()
        {
            var colorGroups = await _context.ColorGroups.ToListAsync();
            return Ok(colorGroups);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetColorGroup(int id)
        {
            var colorGroup = await _context.ColorGroups.FindAsync(id);
            if (colorGroup == null) return NotFound();
            return Ok(colorGroup);
        }

        [HttpPost]
        public async Task<IActionResult> AddColorGroup([FromBody] ColorGroup colorGroup)
        {
            _context.ColorGroups.Add(colorGroup);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetColorGroup), new { id = colorGroup.Id }, colorGroup);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateColorGroup(int id,[FromBody] ColorGroup colorGroup)
        {
            var existingColorGroup = await _context.ColorGroups.FindAsync(id);
            if (existingColorGroup == null) return NotFound();

            existingColorGroup.Name = colorGroup.Name;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.ColorGroups.Any(cg => cg.Id == id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColorGroup(int id)
        {
            var colorGroup = await _context.ColorGroups.FindAsync(id);
            if (colorGroup == null) return NotFound();

            _context.ColorGroups.Remove(colorGroup);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
