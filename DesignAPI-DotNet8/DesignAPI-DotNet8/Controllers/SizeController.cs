using DesignAPI_DotNet8.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DesignAPI_DotNet8.Models.Sizes;

[ApiController]
[Route("api/[controller]")]
public class SizeController : ControllerBase
{
    private readonly DataContext _context;

    public SizeController(DataContext context)
    {
        _context = context;
    }

    // Create a new Size
    [HttpPost]
    public async Task<ActionResult<Size>> CreateSize(Size size)
    {
        _context.Sizes.Add(size);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSize), new { id = size.Id }, size);
    }

    // Read a single Size
    [HttpGet("{id}")]
    public async Task<ActionResult<Size>> GetSize(int id)
    {
        var size = await _context.Sizes.FindAsync(id);

        if (size == null)
        {
            return NotFound();
        }

        return size;
    }

    // Read all Sizes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Size>>> GetSizes()
    {
        return await _context.Sizes.ToListAsync();
    }

    // Update a Size
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSize(int id, Size size)
    {
        if (id != size.Id)
        {
            return BadRequest();
        }

        _context.Entry(size).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // Delete a Size
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSize(int id)
    {
        var size = await _context.Sizes.FindAsync(id);

        if (size == null)
        {
            return NotFound();
        }

        _context.Sizes.Remove(size);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
