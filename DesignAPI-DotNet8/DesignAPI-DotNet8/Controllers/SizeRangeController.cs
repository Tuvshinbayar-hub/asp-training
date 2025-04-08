using DesignAPI_DotNet8.Data;
using DesignAPI_DotNet8.DTO;
using DesignAPI_DotNet8.Models.Sizes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class SizeRangeController : ControllerBase
{
    private readonly DataContext _context;

    public SizeRangeController(DataContext context)
    {
        _context = context;
    }

    // Create a new SizeRange
    [HttpPost]
    public async Task<ActionResult<SizeRange>> CreateSizeRange(SizeRangeDto sizeRangeDto)
    {
        var dimensionType = await _context.DimensionTypes.FindAsync(sizeRangeDto.Dimension1TypeId);
        if (dimensionType == null)
        {
            throw new Exception("DimensionType does not exist");
        }
        var newSizeRange = new SizeRange
        {
            SizeRangeName = sizeRangeDto.SizeRangeName,
            Dimension1TypeId = sizeRangeDto.Dimension1TypeId,
            Dimension1Type = dimensionType,
            Description = sizeRangeDto.Description,
        };
        
        _context.SizeRanges.Add(newSizeRange);
        await _context.SaveChangesAsync();

        return newSizeRange;
    }

    // Read a single SizeRange
    [HttpGet("{id}")]
    public async Task<ActionResult<SizeRange>> GetSizeRange(int id)
    {
        var sizeRange = await _context.SizeRanges
                                      .Include(sr => sr.Sizes)
                                      .FirstOrDefaultAsync(sr => sr.Id == id);

        if (sizeRange == null)
        {
            return NotFound();
        }

        return sizeRange;
    }

    // Read all SizeRanges
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SizeRange>>> GetSizeRanges()
    {
        return await _context.SizeRanges
            .Include(sr => sr.Dimension1Type)
            .Include(sr => sr.ProductTypes)
            .Include(sr => sr.BaseSize)
            .Include(sr => sr.Sizes).ToListAsync();
    }

    // Update a SizeRange
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSizeRange(int id, SizeRangeDto sizeRangeDto)
    {
        if (id != sizeRangeDto.Id)
        {
            return BadRequest();
        }

        var existingSizeRange = await _context.SizeRanges
                                      .Include(sr => sr.Sizes)
                                      .Include(sr => sr.ProductTypes)
                                      .FirstOrDefaultAsync(sr => sr.Id == id);

        if (existingSizeRange == null)
        {
            return NotFound();
        }

        existingSizeRange.Description = sizeRangeDto.Description;
        existingSizeRange.SizeRangeName = sizeRangeDto.SizeRangeName;
        existingSizeRange.Dimension1TypeId = sizeRangeDto.Dimension1TypeId;

        // Load the related Sizes by their names
        if (sizeRangeDto.SizeNames != null)
        {
            // Detach Sizes not in SizeNames
            var sizesToRemove = existingSizeRange.Sizes
                .Where(s => !sizeRangeDto.SizeNames.Contains(s.SizeName))
                .ToList();

            foreach (var size in sizesToRemove)
            {
                existingSizeRange.Sizes.Remove(size);
            }

            // Add new Sizes not already attached
            var existingSizeNames = existingSizeRange.Sizes.Select(s => s.SizeName).ToHashSet();
            var newSizes = await _context.Sizes
                .Where(s => sizeRangeDto.SizeNames.Contains(s.SizeName) && !existingSizeNames.Contains(s.SizeName))
                .ToListAsync();

            existingSizeRange.Sizes.AddRange(newSizes);
        }
        else
        {
            // If SizeNames is null, remove all Sizes
            existingSizeRange.Sizes.Clear();
        }

        if (sizeRangeDto.ProductTypeIds != null)
        {
            // Detach ProductTypes not in ProductTypeIds
            var productTypesToRemove = existingSizeRange.ProductTypes
                .Where(pt => !sizeRangeDto.ProductTypeIds.Contains(pt.Id))
                .ToList();

            foreach (var productType in productTypesToRemove)
            {
                existingSizeRange.ProductTypes.Remove(productType);
            }

            // Add new ProductTypes not already attached
            var existingProductTypeIds = existingSizeRange.ProductTypes.Select(pt => pt.Id).ToHashSet();
            var newProductTypes = await _context.ProductTypes
                .Where(pt => sizeRangeDto.ProductTypeIds.Contains(pt.Id) && !existingProductTypeIds.Contains(pt.Id))
                .ToListAsync();

            existingSizeRange.ProductTypes.AddRange(newProductTypes);
        }
        else
        {
            // If ProductTypeIds is null, remove all ProductTypes
            existingSizeRange.ProductTypes.Clear();
        }



        _context.Entry(existingSizeRange).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // Delete a SizeRange
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSizeRange(int id)
    {
        var sizeRange = await _context.SizeRanges.FindAsync(id);

        if (sizeRange == null)
        {
            return NotFound();
        }

        _context.SizeRanges.Remove(sizeRange);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}