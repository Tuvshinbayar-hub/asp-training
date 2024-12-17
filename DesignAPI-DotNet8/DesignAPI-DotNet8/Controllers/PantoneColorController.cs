using DesignAPI_DotNet8.Data;
using DesignAPI_DotNet8.Models.Colors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PantoneColorController : ControllerBase
    {
        private readonly DataContext _context;

        public PantoneColorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPantoneColors()
        {
            var pantoneColors = await _context.PantoneColors.ToListAsync();
            return Ok(pantoneColors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPantoneColor(int id)
        {
            var pantoneColor = await _context.PantoneColors.FindAsync(id);
            if (pantoneColor == null) return NotFound();
            return Ok(pantoneColor);
        }

        [HttpPost]
        public async Task<IActionResult> AddPantoneColor([FromBody] PantoneColor pantoneColor)
        {
            _context.PantoneColors.Add(pantoneColor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPantoneColor), new { id = pantoneColor.Id }, pantoneColor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePantoneColor(int id, [FromBody] PantoneColor pantoneColor)
        {
            var existingPantoneColor = await _context.PantoneColors.FindAsync(id);
            if (existingPantoneColor == null) return NotFound();

            // Update properties
            existingPantoneColor.PantoneColorCode = pantoneColor.PantoneColorCode;
            existingPantoneColor.PantoneColorName = pantoneColor.PantoneColorName;
            existingPantoneColor.RgbHex = pantoneColor.RgbHex;
            existingPantoneColor.ColorGroupId = pantoneColor.ColorGroupId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.PantoneColors.Any(pc => pc.Id == id)) return NotFound();
                throw;
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePantoneColor(int id)
        {
            var pantoneColor = await _context.PantoneColors.FindAsync(id);
            if (pantoneColor == null) return NotFound();
            _context.PantoneColors.Remove(pantoneColor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
