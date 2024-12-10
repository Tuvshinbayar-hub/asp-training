using DesignAPI_DotNet8.Data;
using DesignAPI_DotNet8.DTO;
using DesignAPI_DotNet8.Models.Grading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignAPI_DotNet8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DimensionsController : ControllerBase
    {
        private readonly DataContext _context;

        public DimensionsController(DataContext context)
        {
            _context = context;
        }

        // Create a new Dimension
        [HttpPost]
        public async Task<ActionResult<Dimension>> CreateDimension(DimensionDto dimensionDto)
        {
            var dimension = new Dimension
            {
                DimensionName = dimensionDto.DimensionName,
                ImageId = dimensionDto.ImageId,
                Description = dimensionDto.Description,
                IsActive = dimensionDto.IsActive
            };

            if (dimensionDto.ProductTypeIds != null && dimensionDto.ProductTypeIds.Any())
            {
                dimension.ProductType = await _context.ProductTypes
                                                      .Where(pt => dimensionDto.ProductTypeIds.Contains(pt.Id))
                                                      .ToListAsync();
            }

            _context.Dimensions.Add(dimension);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDimensionById), new { id = dimension.Id }, dimension);
        }

        // Read Dimension by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Dimension>> GetDimensionById(int id)
        {
            var dimension = await _context.Dimensions
                                          .Include(d => d.Image)
                                          .Include(d => d.ProductType)
                                          .FirstOrDefaultAsync(d => d.Id == id);

            if (dimension == null)
            {
                return NotFound();
            }

            return dimension;
        }

        // Read all Dimensions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dimension>>> GetDimensions()
        {
            return await _context.Dimensions
                                 .Include(d => d.Image)
                                 .Include(d => d.ProductType)
                                 .ToListAsync();
        }

        // Update Dimension
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDimension(int id, DimensionDto dimensionDto)
        {
            if (id != dimensionDto.Id)
            {
                return BadRequest();
            }

            var existingDimension = await _context.Dimensions
                                                  .Include(d => d.ProductType)
                                                  .FirstOrDefaultAsync(d => d.Id == id);

            if (existingDimension == null)
            {
                return NotFound();
            }

            existingDimension.DimensionName = dimensionDto.DimensionName;
            existingDimension.ImageId = dimensionDto.ImageId;
            existingDimension.Description = dimensionDto.Description;
            existingDimension.IsActive = dimensionDto.IsActive;

            // Update ProductTypes
            if (dimensionDto.ProductTypeIds != null)
            {
                var existingProductTypeIds = existingDimension.ProductType.Select(pt => pt.Id).ToHashSet();
                var incomingProductTypeIds = new HashSet<int>(dimensionDto.ProductTypeIds);

                // Remove ProductTypes that are not in the incoming IDs
                existingDimension.ProductType.RemoveAll(pt => !incomingProductTypeIds.Contains(pt.Id));

                // Add new ProductTypes
                var newProductTypes = await _context.ProductTypes
                                                    .Where(pt => incomingProductTypeIds.Contains(pt.Id) && !existingProductTypeIds.Contains(pt.Id))
                                                    .ToListAsync();
                existingDimension.ProductType.AddRange(newProductTypes);
            }

            _context.Entry(existingDimension).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimensionExists(id))
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

        // Delete Dimension
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDimension(int id)
        {
            var dimension = await _context.Dimensions.FindAsync(id);
            if (dimension == null)
            {
                return NotFound();
            }

            _context.Dimensions.Remove(dimension);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DimensionExists(int id)
        {
            return _context.Dimensions.Any(e => e.Id == id);
        }
    }

}
