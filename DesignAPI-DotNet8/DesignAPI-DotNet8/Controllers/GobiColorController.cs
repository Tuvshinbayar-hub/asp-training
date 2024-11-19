﻿using DesignAPI_DotNet8.Data;
using DesignAPI_DotNet8.Models.Colors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GobiColorController : ControllerBase
    {
        private readonly DataContext _context;

        public GobiColorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetGobiColors()
        {
            var gobiColors = await _context.GobiColors
                .Include(gc => gc.ColorType)
                .Include(gc => gc.ColorShade)
                .Include(gc => gc.PantoneColor)
                .Include(gc => gc.ColorRecipe)
                .ToListAsync();
            return Ok(gobiColors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGobiColor(int id)
        {
            var gobiColor = await _context.GobiColors
                .Include(gc => gc.ColorType)
                .Include(gc => gc.ColorShade)
                .Include(gc => gc.PantoneColor)
                .Include(gc => gc.ColorRecipe)
                .FirstOrDefaultAsync(gc => gc.Id == id);

            if (gobiColor == null) return NotFound();
            return Ok(gobiColor);
        }

        [HttpPost]
        public async Task<IActionResult> AddGobiColor([FromBody] GobiColor gobiColor)
        {
            _context.GobiColors.Add(gobiColor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGobiColor), new { id = gobiColor.Id }, gobiColor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGobiColor(int id, [FromBody] GobiColor gobiColor)
        {
            if (id != gobiColor.Id) return BadRequest();

            _context.Entry(gobiColor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.GobiColors.Any(gc => gc.Id == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGobiColor(int id)
        {
            var gobiColor = await _context.GobiColors.FindAsync(id);
            if (gobiColor == null) return NotFound();

            _context.GobiColors.Remove(gobiColor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}