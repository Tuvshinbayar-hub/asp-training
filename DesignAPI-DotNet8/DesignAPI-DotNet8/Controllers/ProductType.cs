using DesignAPI_DotNet8.Data;
using DesignAPI_DotNet8.Models.Sizes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ProductTypesController : ControllerBase
{
    private readonly DataContext _context;

    public ProductTypesController(DataContext context)
    {
        _context = context;
    }

    // Create a new ProductType
    [HttpPost]
    public async Task<ActionResult<ProductType>> CreateProductType(ProductType productType)
    {
        var newProductType = new ProductType
        {
            Name = productType.Name
        };

        _context.ProductTypes.Add(productType);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProductTypeById), new { id = productType.Id }, productType);
    }

    // Read a ProductType by Id
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductType>> GetProductTypeById(int id)
    {
        var productType = await _context.ProductTypes.FindAsync(id);

        if (productType == null)
        {
            return NotFound();
        }

        return productType;
    }

    // Read all ProductTypes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductType>>> GetProductTypes()
    {
        return await _context.ProductTypes.ToListAsync();
    }

    // Update a ProductType
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductType(int id, ProductType productType)
    {
        if (id != productType.Id)
        {
            return BadRequest();
        }

        var existingProductType = await _context.ProductTypes.FindAsync(id);
        if (productType == null)
        {
            return NotFound();
        }

        existingProductType.Name = productType.Name;

        _context.Entry(existingProductType).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductTypeExists(id))
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

    // Delete a ProductType
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductType(int id)
    {
        var productType = await _context.ProductTypes.FindAsync(id);
        if (productType == null)
        {
            return NotFound();
        }

        _context.ProductTypes.Remove(productType);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductTypeExists(int id)
    {
        return _context.ProductTypes.Any(e => e.Id == id);
    }
}
