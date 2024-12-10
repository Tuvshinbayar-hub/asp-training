using DesignAPI_DotNet8.Data;
using DesignAPI_DotNet8.DTO;
using DesignAPI_DotNet8.Models.Grading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignAPI_DotNet8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToleranceDetailsController : ControllerBase
    {
        private readonly DataContext _context;

        public ToleranceDetailsController(DataContext context)
        {
            _context = context;
        }

        // Create a new ToleranceDetail
        [HttpPost]
        public async Task<ActionResult<ToleranceDetail>> CreateToleranceDetail(ToleranceDetailDto toleranceDetailDto)
        {
            var toleranceDetail = new ToleranceDetail
            {
                Tolerance = toleranceDetailDto.Tolerance,
                DimensionName = toleranceDetailDto.DimensionName,
                ToleranceMinus = toleranceDetailDto.ToleranceMinus,
                TolerancePlus = toleranceDetailDto.TolerancePlus
            };

            _context.ToleranceDetails.Add(toleranceDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetToleranceDetailById), new { id = toleranceDetail.Id }, toleranceDetail);
        }

        // Read ToleranceDetail by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ToleranceDetail>> GetToleranceDetailById(int id)
        {
            var toleranceDetail = await _context.ToleranceDetails
                                                .Include(td => td.Dimension)
                                                .FirstOrDefaultAsync(td => td.Id == id);

            if (toleranceDetail == null)
            {
                return NotFound();
            }

            return toleranceDetail;
        }

        // Read all ToleranceDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToleranceDetail>>> GetToleranceDetails()
        {
            return await _context.ToleranceDetails
                                 .Include(td => td.Dimension)
                                 .ToListAsync();
        }

        // Update ToleranceDetail
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToleranceDetail(int id, ToleranceDetailDto toleranceDetailDto)
        {
            if (id != toleranceDetailDto.Id)
            {
                return BadRequest();
            }

            var existingToleranceDetail = await _context.ToleranceDetails.FindAsync(id);

            if (existingToleranceDetail == null)
            {
                return NotFound();
            }

            existingToleranceDetail.Tolerance = toleranceDetailDto.Tolerance;
            existingToleranceDetail.DimensionName = toleranceDetailDto.DimensionName;
            existingToleranceDetail.ToleranceMinus = toleranceDetailDto.ToleranceMinus;
            existingToleranceDetail.TolerancePlus = toleranceDetailDto.TolerancePlus;

            _context.Entry(existingToleranceDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToleranceDetailExists(id))
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

        // Delete ToleranceDetail
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToleranceDetail(int id)
        {
            var toleranceDetail = await _context.ToleranceDetails.FindAsync(id);
            if (toleranceDetail == null)
            {
                return NotFound();
            }

            _context.ToleranceDetails.Remove(toleranceDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToleranceDetailExists(int id)
        {
            return _context.ToleranceDetails.Any(e => e.Id == id);
        }
    }

}
