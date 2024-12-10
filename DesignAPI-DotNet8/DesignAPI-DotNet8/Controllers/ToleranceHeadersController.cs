using DesignAPI_DotNet8.Data;
using DesignAPI_DotNet8.DTO;
using DesignAPI_DotNet8.Models.Grading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignAPI_DotNet8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToleranceHeadersController : ControllerBase
    {
        private readonly DataContext _context;

        public ToleranceHeadersController(DataContext context)
        {
            _context = context;
        }

        // Create a new ToleranceHeader
        [HttpPost]
        public async Task<ActionResult<ToleranceHeader>> CreateToleranceHeader(ToleranceHeaderDto toleranceHeaderDto)
        {
            var toleranceHeader = new ToleranceHeader
            {
                Tolerance = toleranceHeaderDto.Tolerance,
                Description = toleranceHeaderDto.Description,
                IsActive = toleranceHeaderDto.IsActive
            };

            if (toleranceHeaderDto.DimensionNames != null && toleranceHeaderDto.DimensionNames.Any())
            {
                toleranceHeader.Dimensions = await _context.Dimensions
                                                          .Where(d => toleranceHeaderDto.DimensionNames.Contains(d.DimensionName))
                                                          .ToListAsync();
            }

            if (toleranceHeaderDto.Increments != null && toleranceHeaderDto.Increments.Any())
            {
                toleranceHeader.GradingHeaders = await _context.GradingHeaders
                                                               .Where(gh => toleranceHeaderDto.Increments.Contains(gh.Increment))
                                                               .ToListAsync();
            }

            _context.ToleranceHeaders.Add(toleranceHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetToleranceHeaderById), new { id = toleranceHeader.Id }, toleranceHeader);
        }

        // Read ToleranceHeader by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ToleranceHeader>> GetToleranceHeaderById(int id)
        {
            var toleranceHeader = await _context.ToleranceHeaders
                                                .Include(th => th.ToleranceDetail)
                                                .Include(th => th.Dimensions)
                                                .Include(th => th.GradingHeaders)
                                                .FirstOrDefaultAsync(th => th.Id == id);

            if (toleranceHeader == null)
            {
                return NotFound();
            }

            return toleranceHeader;
        }

        // Read all ToleranceHeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToleranceHeader>>> GetToleranceHeaders()
        {
            return await _context.ToleranceHeaders
                                 .Include(th => th.ToleranceDetail)
                                 .Include(th => th.Dimensions)
                                 .Include(th => th.GradingHeaders)
                                 .ToListAsync();
        }

        // Update ToleranceHeader
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToleranceHeader(int id, ToleranceHeaderDto toleranceHeaderDto)
        {
            if (id != toleranceHeaderDto.Id)
            {
                return BadRequest();
            }

            var existingToleranceHeader = await _context.ToleranceHeaders
                                                        .Include(th => th.Dimensions)
                                                        .Include(th => th.GradingHeaders)
                                                        .FirstOrDefaultAsync(th => th.Id == id);

            if (existingToleranceHeader == null)
            {
                return NotFound();
            }

            existingToleranceHeader.Tolerance = toleranceHeaderDto.Tolerance;
            existingToleranceHeader.Description = toleranceHeaderDto.Description;
            existingToleranceHeader.IsActive = toleranceHeaderDto.IsActive;

            // Update Dimensions
            if (toleranceHeaderDto.DimensionNames != null)
            {
                var existingDimensionNames = existingToleranceHeader.Dimensions.Select(d => d.DimensionName).ToHashSet();
                var incomingDimensionNames = new HashSet<string>(toleranceHeaderDto.DimensionNames);

                // Remove Dimensions that are not in the incoming names
                existingToleranceHeader.Dimensions.RemoveAll(d => !incomingDimensionNames.Contains(d.DimensionName));

                // Add new Dimensions
                var newDimensions = await _context.Dimensions
                                                  .Where(d => incomingDimensionNames.Contains(d.DimensionName) && !existingDimensionNames.Contains(d.DimensionName))
                                                  .ToListAsync();
                existingToleranceHeader.Dimensions.AddRange(newDimensions);
            }

            // Update GradingHeaders
            if (toleranceHeaderDto.Increments != null)
            {
                var existingIncrements = existingToleranceHeader.GradingHeaders.Select(gh => gh.Increment).ToHashSet();
                var incomingIncrements = new HashSet<string>(toleranceHeaderDto.Increments);

                // Remove GradingHeaders that are not in the incoming increments
                existingToleranceHeader.GradingHeaders.RemoveAll(gh => !incomingIncrements.Contains(gh.Increment));

                // Add new GradingHeaders
                var newGradingHeaders = await _context.GradingHeaders
                                                      .Where(gh => incomingIncrements.Contains(gh.Increment) && !existingIncrements.Contains(gh.Increment))
                                                      .ToListAsync();
                existingToleranceHeader.GradingHeaders.AddRange(newGradingHeaders);
            }

            _context.Entry(existingToleranceHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToleranceHeaderExists(id))
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

        // Delete ToleranceHeader
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToleranceHeader(int id)
        {
            var toleranceHeader = await _context.ToleranceHeaders.FindAsync(id);
            if (toleranceHeader == null)
            {
                return NotFound();
            }

            _context.ToleranceHeaders.Remove(toleranceHeader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToleranceHeaderExists(int id)
        {
            return _context.ToleranceHeaders.Any(e => e.Id == id);
        }
    }

}
