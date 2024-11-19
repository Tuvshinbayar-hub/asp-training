using DesignAPI_DotNet8.Data;
using DesignAPI_DotNet8.Models.Colors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorTypeController : ControllerBase
    {
        private readonly DataContext _context;

        public ColorTypeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetColorTypes()
        {
            var colorTypes = await _context.ColorTypes.ToListAsync();
            return Ok(colorTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetColorType(int id)
        {
            var colorType = await _context.ColorTypes.FindAsync(id);
            if (colorType == null) return NotFound();
            return Ok(colorType);
        }

        [HttpPost]
        public async Task<IActionResult> AddColorType([FromBody] ColorType colorType)
        {
            _context.ColorTypes.Add(colorType);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetColorType), new { id = colorType.Id }, colorType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateColorType(int id, [FromBody] ColorType colorType)
        {
            if (id != colorType.Id) return BadRequest();
            _context.Entry(colorType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColorType(int id)
        {
            var colorType = await _context.ColorTypes.FindAsync(id);
            if (colorType == null) return NotFound();
            _context.ColorTypes.Remove(colorType);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
