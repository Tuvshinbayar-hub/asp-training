using DesignAPI_DotNet8.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace DesignAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Design>>> GetAllDesign()
        {
            var designs = new List<Design> { 
                new Design 
                { 
                    Id = 1, 
                    Code = "AAABBBCCC000111"
                },
                new Design
                {
                    Id = 2,
                    Code = "AAABBBCCC000112"
                }
            };

            return Ok(designs);
        }
    }
}
