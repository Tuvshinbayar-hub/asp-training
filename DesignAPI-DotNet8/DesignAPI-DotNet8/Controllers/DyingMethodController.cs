using DesignAPI_DotNet8.Data;
using DesignAPI_DotNet8.Models.Colors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DyingMethodController : ControllerBase
    {
        private readonly DataContext _context;

        public DyingMethodController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDyingMethods()
        {
            var dyingMethods = await _context.DyingMethods.ToListAsync();
            return Ok(dyingMethods);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDyingMethod(int id)
        {
            var dyingMethod = await _context.DyingMethods.FindAsync(id);
            if (dyingMethod == null) return NotFound();
            return Ok(dyingMethod);
        }

        [HttpPost]
        public async Task<IActionResult> AddDyingMethod([FromBody] DyingMethod dyingMethod)
        {
            _context.DyingMethods.Add(dyingMethod);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDyingMethod), new { id = dyingMethod.Id }, dyingMethod);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDyingMethod(int id, [FromBody] DyingMethod dyingMethod)
        {
            var existingDyingMethod = await _context.DyingMethods.FindAsync(id);
            if (existingDyingMethod == null) return NotFound();

            existingDyingMethod.Name = dyingMethod.Name;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.DyingMethods.Any(dm => dm.Id == id)) return NotFound();
                throw;
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDyingMethod(int id)
        {
            var dyingMethod = await _context.DyingMethods.FindAsync(id);
            if (dyingMethod == null) return NotFound();

            _context.DyingMethods.Remove(dyingMethod);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

