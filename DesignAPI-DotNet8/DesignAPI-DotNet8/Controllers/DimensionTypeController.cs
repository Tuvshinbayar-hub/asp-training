using DesignAPI_DotNet8.Data;
using DesignAPI_DotNet8.Models.Sizes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class DimensionTypeController : ControllerBase
{
    private readonly DataContext _context;

    public DimensionTypeController(DataContext context)
    {
        _context = context;
    }

    // Create a new DimensionType
    [HttpPost]
    public async Task<ActionResult<DimensionType>> CreateDimensionType(DimensionType dimensionType)
    {
        _context.DimensionTypes.Add(dimensionType);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDimensionType), new { id = dimensionType.Id }, dimensionType);
    }

    // Read a single DimensionType
    [HttpGet("{id}")]
    public async Task<ActionResult<DimensionType>> GetDimensionType(int id)
    {
        var dimensionType = await _context.DimensionTypes.FindAsync(id);

        if (dimensionType == null)
        {
            return NotFound();
        }

        return dimensionType;
    }

    // Read all DimensionTypes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DimensionType>>> GetDimensionTypes()
    {
        return await _context.DimensionTypes.ToListAsync();
    }

    // Update a DimensionType
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDimensionType(int id, DimensionType dimensionType)
    {
        if (id != dimensionType.Id)
        {
            return BadRequest();
        }

        _context.Entry(dimensionType).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // Delete a DimensionType
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDimensionType(int id)
    {
        var dimensionType = await _context.DimensionTypes.FindAsync(id);

        if (dimensionType == null)
        {
            return NotFound();
        }

        _context.DimensionTypes.Remove(dimensionType);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
