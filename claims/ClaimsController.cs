using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace ClaimsService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClaimsController : ControllerBase
    {
        private static ConcurrentDictionary<string, object> claims = new();

        [HttpPost]
        public IActionResult CreateClaim([FromBody] object claim)
        {
            var id = System.Guid.NewGuid().ToString();
            claims[id] = claim;
            return Created("", new { claim_id = id, claim });
        }

        [HttpGet("{id}")]
        public IActionResult GetClaim(string id)
        {
            if (claims.TryGetValue(id, out var claim))
                return Ok(new { claim_id = id, claim });
            return NotFound(new { error = "Claim not found" });
        }
    }
}