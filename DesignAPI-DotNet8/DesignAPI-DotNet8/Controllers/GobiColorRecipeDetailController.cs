using DesignAPI_DotNet8.Data;
using DesignAPI_DotNet8.Models.Colors;
using DesignAPI_DotNet8.Models.GobiColor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GobiColorRecipeDetailController : ControllerBase
    {
        private readonly DataContext _context;

        public GobiColorRecipeDetailController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaintTypes()
        {
            var paintTypes = await _context.GobiColorRecipeDetail.ToListAsync();
            return Ok(paintTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaintType(int id)
        {
            var paintType = await _context.GobiColorRecipeDetail.FindAsync(id);
            if (paintType == null) return NotFound();
            return Ok(paintType);
        }

        [HttpPost]
        public async Task<IActionResult> AddPaintType([FromBody] GobiColorRecipeDetail paintType)
        {
            _context.GobiColorRecipeDetail.Add(paintType);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPaintType), new { id = paintType.Id }, paintType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePaintType(int id, [FromBody] GobiColorRecipeDetail paintType)
        {
            var existingPaintType = await _context.GobiColorRecipeDetail.FindAsync(id);
            if (existingPaintType == null) return NotFound();

            existingPaintType.PaintType = paintType.PaintType;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.GobiColorRecipeDetail.Any(pt => pt.Id == id)) return NotFound();
                throw;
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaintType(int id)
        {
            var paintType = await _context.GobiColorRecipeDetail.FindAsync(id);
            if (paintType == null) return NotFound();

            _context.GobiColorRecipeDetail.Remove(paintType);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
