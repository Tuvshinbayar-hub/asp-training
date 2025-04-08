using DesignAPI_DotNet8.Data;
using DesignAPI_DotNet8.Models.Colors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class GobiColorRecipeHeaderController : ControllerBase
{
    private readonly DataContext _context;

    public GobiColorRecipeHeaderController(DataContext context)
    {
        _context = context;
    }

    // GET: api/ColorRecipe
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GobiColorRecipeHeader>>> GetColorRecipes()
    {
        return await _context.GobiColorRecipeHeader.ToListAsync();
    }

    // GET: api/ColorRecipe/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<GobiColorRecipeHeader>> GetColorRecipe(int id)
    {
        var colorRecipe = await _context.GobiColorRecipeHeader.FindAsync(id);
        if (colorRecipe == null) return NotFound();

        return colorRecipe;
    }

    // POST: api/ColorRecipe
    [HttpPost]
    public async Task<ActionResult<GobiColorRecipeHeader>> CreateColorRecipe([FromBody] GobiColorRecipeHeader colorRecipe)
    {
        _context.GobiColorRecipeHeader.Add(colorRecipe);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetColorRecipe), new { id = colorRecipe.Id }, colorRecipe);
    }

    // PUT: api/ColorRecipe/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateColorRecipe(int id, [FromBody] GobiColorRecipeHeader colorRecipe)
    {
        var existingColorRecipe = await _context.GobiColorRecipeHeader.FindAsync(id);
        if (existingColorRecipe == null) return NotFound();

        existingColorRecipe.ColorComposition = colorRecipe.ColorComposition;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/ColorRecipe/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteColorRecipe(int id)
    {
        var colorRecipe = await _context.GobiColorRecipeHeader.FindAsync(id);
        if (colorRecipe == null) return NotFound();

        _context.GobiColorRecipeHeader.Remove(colorRecipe);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
