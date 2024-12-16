using DesignAPI_DotNet8.Data;
using DesignAPI_DotNet8.DTO;
using DesignAPI_DotNet8.Models.Grading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignAPI_DotNet8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradingHeadersController : ControllerBase
    {
        private readonly DataContext _context;

        public GradingHeadersController(DataContext context)
        {
            _context = context;
        }

        // Create a new GradingHeader
        [HttpPost]
        public async Task<ActionResult<GradingHeader>> CreateGradingHeader(GradingHeaderDto gradingHeaderDto)
        {
            var gradingHeader = new GradingHeader
            {
                Increment = gradingHeaderDto.Increment,
                Description = gradingHeaderDto.Description,
                IsActive = gradingHeaderDto.IsActive
            };

            if (gradingHeaderDto.ProductTypeIds != null && gradingHeaderDto.ProductTypeIds.Any())
            {
                gradingHeader.ProductTypes = await _context.ProductTypes
                                                           .Where(pt => gradingHeaderDto.ProductTypeIds.Contains(pt.Id))
                                                           .ToListAsync();
            }

            if (gradingHeaderDto.SizeNames != null && gradingHeaderDto.SizeNames.Any())
            {
                gradingHeader.Sizes = await _context.Sizes
                                                    .Where(s => gradingHeaderDto.SizeNames.Contains(s.SizeName))
                                                    .ToListAsync();
            }

            _context.GradingHeaders.Add(gradingHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGradingHeaderById), new { id = gradingHeader.Id }, gradingHeader);
        }

        // Read GradingHeader by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<GradingHeader>> GetGradingHeaderById(int id)
        {
            var gradingHeader = await _context.GradingHeaders
                                              .Include(gh => gh.ProductTypes)
                                              .Include(gh => gh.Sizes)
                                              .FirstOrDefaultAsync(gh => gh.Id == id);

            if (gradingHeader == null)
            {
                return NotFound();
            }

            return gradingHeader;
        }

        // Read all GradingHeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradingHeader>>> GetGradingHeaders()
        {
            return await _context.GradingHeaders
                                 .Include(gh => gh.ProductTypes)
                                 .Include(gh => gh.Sizes)
                                 .Include(gh => gh.GradingPitches)
                                 .ToListAsync();
        }

        // Update GradingHeader
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGradingHeader(int id, GradingHeaderDto gradingHeaderDto)
        {
            if (id != gradingHeaderDto.Id)
            {
                return BadRequest();
            }

            var existingGradingHeader = await _context.GradingHeaders
                                                      .Include(gh => gh.ProductTypes)
                                                      .Include(gh => gh.Sizes)
                                                      .FirstOrDefaultAsync(gh => gh.Id == id);

            if (existingGradingHeader == null)
            {
                return NotFound();
            }

            existingGradingHeader.Increment = gradingHeaderDto.Increment;
            existingGradingHeader.Description = gradingHeaderDto.Description;
            existingGradingHeader.IsActive = gradingHeaderDto.IsActive;

            // Update ProductTypes
            if (gradingHeaderDto.ProductTypeIds != null)
            {
                var existingProductTypeIds = existingGradingHeader.ProductTypes.Select(pt => pt.Id).ToHashSet();
                var incomingProductTypeIds = new HashSet<int>(gradingHeaderDto.ProductTypeIds);

                // Remove ProductTypes that are not in the incoming IDs
                existingGradingHeader.ProductTypes.RemoveAll(pt => !incomingProductTypeIds.Contains(pt.Id));

                // Add new ProductTypes
                var newProductTypes = await _context.ProductTypes
                                                    .Where(pt => incomingProductTypeIds.Contains(pt.Id) && !existingProductTypeIds.Contains(pt.Id))
                                                    .ToListAsync();
                existingGradingHeader.ProductTypes.AddRange(newProductTypes);
            }

            // Update Sizes
            if (gradingHeaderDto.SizeNames != null)
            {
                var existingSizeNames = existingGradingHeader.Sizes.Select(s => s.SizeName).ToHashSet();
                var incomingSizeNames = new HashSet<string>(gradingHeaderDto.SizeNames);

                // Remove Sizes that are not in the incoming IDs
                existingGradingHeader.Sizes.RemoveAll(s => !incomingSizeNames.Contains(s.SizeName));

                // Add new Sizes
                var newSizes = await _context.Sizes
                                             .Where(s => incomingSizeNames.Contains(s.SizeName) && !existingSizeNames.Contains(s.SizeName))
                                             .ToListAsync();
                existingGradingHeader.Sizes.AddRange(newSizes);
            }

            _context.Entry(existingGradingHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradingHeaderExists(id))
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

        // Delete GradingHeader
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGradingHeader(int id)
        {
            var gradingHeader = await _context.GradingHeaders.FindAsync(id);
            if (gradingHeader == null)
            {
                return NotFound();
            }

            _context.GradingHeaders.Remove(gradingHeader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GradingHeaderExists(int id)
        {
            return _context.GradingHeaders.Any(e => e.Id == id);
        }
    }
    }

