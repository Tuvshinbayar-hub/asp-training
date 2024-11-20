using DesignAPI_DotNet8.Data;
using DesignAPI_DotNet8.Models.Colors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ColorShadeController : ControllerBase
{
    private readonly DataContext _context;

    public ColorShadeController(DataContext context)
    {
        _context = context;
    }

    // GET: api/ColorShade
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ColorShade>>> GetColorShades()
    {
        return await _context.ColorShades.ToListAsync();
    }

    // GET: api/ColorShade/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ColorShade>> GetColorShade(int id)
    {
        var colorShade = await _context.ColorShades.FindAsync(id);
        if (colorShade == null) return NotFound();

        return colorShade;
    }

    // POST: api/ColorShade
    [HttpPost]
    public async Task<ActionResult<ColorShade>> CreateColorShade([FromBody] ColorShade colorShade)
    {
        _context.ColorShades.Add(colorShade);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetColorShade), new { id = colorShade.Id }, colorShade);
    }

    // PUT: api/ColorShade/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateColorShade(int id, [FromBody] ColorShade colorShade)
    {
        var existingColorShade = await _context.ColorShades.FindAsync(id);
        if (existingColorShade == null) return NotFound();

        existingColorShade.Name = colorShade.Name;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/ColorShade/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteColorShade(int id)
    {
        var colorShade = await _context.ColorShades.FindAsync(id);
        if (colorShade == null) return NotFound();

        _context.ColorShades.Remove(colorShade);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
