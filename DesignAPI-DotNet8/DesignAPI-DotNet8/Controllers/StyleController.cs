using DesignAPI_DotNet8.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesignAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StyleController : ControllerBase
    {
        private readonly IStyleService _styleService;
        public StyleController(IStyleService styleService)
        {
            this._styleService = styleService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetStyles()
        {
            var styles = await _styleService.GetAllStylesAsync();
            return Ok(styles);
        }
    }
}
