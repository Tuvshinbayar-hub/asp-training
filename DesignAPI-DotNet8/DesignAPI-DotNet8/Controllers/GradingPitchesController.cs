using DesignAPI_DotNet8.Data;
using DesignAPI_DotNet8.DTO;
using DesignAPI_DotNet8.Models.Grading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignAPI_DotNet8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradingPitchesController : ControllerBase
    {
        private readonly DataContext _context;

        public GradingPitchesController(DataContext context)
        {
            _context = context;
        }

        // Create a new GradingPitch
        [HttpPost]
        public async Task<ActionResult<GradingPitch>> CreateGradingPitch(GradingPitchDto gradingPitchDto)
        {
            var gradingPitch = new GradingPitch
            {
                Increment = gradingPitchDto.Increment,
                DimensionName = gradingPitchDto.DimensionName,
                ProductTypeId = gradingPitchDto.ProductTypeId,
                Increments = gradingPitchDto.Increments
            };

            _context.GradingPitches.Add(gradingPitch);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGradingPitchById), new { id = gradingPitch.Id }, gradingPitch);
        }

        // Read GradingPitch by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<GradingPitch>> GetGradingPitchById(int id)
        {
            var gradingPitch = await _context.GradingPitches
                                             .Include(gp => gp.ProductType)
                                             .Include(gp => gp.Dimension)
                                             .FirstOrDefaultAsync(gp => gp.Id == id);

            if (gradingPitch == null)
            {
                return NotFound();
            }

            return gradingPitch;
        }

        // Read all GradingPitches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradingPitch>>> GetGradingPitches()
        {
            return await _context.GradingPitches
                                 .Include(gp => gp.ProductType)
                                 .Include(gp => gp.Dimension)
                                 .ToListAsync();
        }

        // Update GradingPitch
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGradingPitch(int id, GradingPitchDto gradingPitchDto)
        {
            if (id != gradingPitchDto.Id)
            {
                return BadRequest();
            }

            var existingGradingPitch = await _context.GradingPitches.FindAsync(id);

            if (existingGradingPitch == null)
            {
                return NotFound();
            }

            existingGradingPitch.Increment = gradingPitchDto.Increment;
            existingGradingPitch.DimensionName = gradingPitchDto.DimensionName;
            existingGradingPitch.ProductTypeId = gradingPitchDto.ProductTypeId;

            _context.Entry(existingGradingPitch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradingPitchExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // Delete GradingPitch
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGradingPitch(int id)
        {
            var gradingPitch = await _context.GradingPitches.FindAsync(id);
            if (gradingPitch == null)
            {
                return NotFound();
            }

            _context.GradingPitches.Remove(gradingPitch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GradingPitchExists(int id)
        {
            return _context.GradingPitches.Any(e => e.Id == id);
        }
    }

}
