using DesignAPI_DotNet8.Data;
using DesignAPI_DotNet8.Models.Colors;
using DesignAPI_DotNet8.Models.GobiColor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaintTypeController : ControllerBase
    {
        private readonly DataContext _context;

        public PaintTypeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaintTypes()
        {
            var paintTypes = await _context.PaintTypes.ToListAsync();
            return Ok(paintTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaintType(int id)
        {
            var paintType = await _context.PaintTypes.FindAsync(id);
            if (paintType == null) return NotFound();
            return Ok(paintType);
        }

        [HttpPost]
        public async Task<IActionResult> AddPaintType([FromBody] PaintType paintType)
        {
            _context.PaintTypes.Add(paintType);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPaintType), new { id = paintType.Id }, paintType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePaintType(int id, [FromBody] PaintType paintType)
        {
            if (id != paintType.Id) return BadRequest();
            _context.Entry(paintType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.PaintTypes.Any(pt => pt.Id == id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaintType(int id)
        {
            var paintType = await _context.PaintTypes.FindAsync(id);
            if (paintType == null) return NotFound();

            _context.PaintTypes.Remove(paintType);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
