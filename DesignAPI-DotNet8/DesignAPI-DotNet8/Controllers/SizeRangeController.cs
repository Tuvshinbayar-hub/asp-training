using DesignAPI_DotNet8.Data;
using DesignAPI_DotNet8.Models.Sizes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DesignAPI_DotNet8.Models.Sizes;

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
    public async Task<ActionResult<SizeRange>> CreateSizeRange(SizeRange sizeRange)
    {
        // Load the related Sizes by their names
        sizeRange.Sizes = await _context.Sizes
                                  .Where(s => sizeRange.Sizes.Select(sz => sz.SizeName).Contains(s.SizeName))
                                  .ToListAsync();

        _context.SizeRanges.Add(sizeRange);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSizeRange), new { id = sizeRange.Id }, sizeRange);
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
        return await _context.SizeRanges.Include(sr => sr.Sizes).ToListAsync();
    }

    // Update a SizeRange
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSizeRange(int id, SizeRange sizeRange)
    {
        if (id != sizeRange.Id)
        {
            return BadRequest();
        }

        var existingSizeRange = await _context.SizeRanges
                                      .Include(sr => sr.Sizes)
                                      .FirstOrDefaultAsync(sr => sr.Id == id);

        if (existingSizeRange == null)
        {
            return NotFound();
        }

        existingSizeRange.SizeRangeName = sizeRange.SizeRangeName;
        existingSizeRange.Dimension1Type = sizeRange.Dimension1Type;

        // Load the related Sizes by their names
        existingSizeRange.Sizes = await _context.Sizes
                                        .Where(s => sizeRange.Sizes.Select(sz => sz.SizeName).Contains(s.SizeName))
                                        .ToListAsync();

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
