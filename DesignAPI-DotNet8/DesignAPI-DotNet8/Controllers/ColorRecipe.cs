using DesignAPI_DotNet8.Data;
using DesignAPI_DotNet8.Models.Colors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ColorRecipeController : ControllerBase
{
    private readonly DataContext _context;

    public ColorRecipeController(DataContext context)
    {
        _context = context;
    }

    // GET: api/ColorRecipe
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ColorRecipe>>> GetColorRecipes()
    {
        return await _context.ColorRecipes.ToListAsync();
    }

    // GET: api/ColorRecipe/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ColorRecipe>> GetColorRecipe(int id)
    {
        var colorRecipe = await _context.ColorRecipes.FindAsync(id);
        if (colorRecipe == null) return NotFound();

        return colorRecipe;
    }

    // POST: api/ColorRecipe
    [HttpPost]
    public async Task<ActionResult<ColorRecipe>> CreateColorRecipe([FromBody] ColorRecipe colorRecipe)
    {
        _context.ColorRecipes.Add(colorRecipe);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetColorRecipe), new { id = colorRecipe.Id }, colorRecipe);
    }

    // PUT: api/ColorRecipe/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateColorRecipe(int id, [FromBody] ColorRecipe colorRecipe)
    {
        var existingColorRecipe = await _context.ColorRecipes.FindAsync(id);
        if (existingColorRecipe == null) return NotFound();

        existingColorRecipe.ColorComposition = colorRecipe.ColorComposition;
        existingColorRecipe.PaintTypes = colorRecipe.PaintTypes;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/ColorRecipe/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteColorRecipe(int id)
    {
        var colorRecipe = await _context.ColorRecipes.FindAsync(id);
        if (colorRecipe == null) return NotFound();

        _context.ColorRecipes.Remove(colorRecipe);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
