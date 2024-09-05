using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodingInterviewQuestionsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        // Public endpoint - accessible to everyone
        [HttpGet("public")]
        public IActionResult GetPublicData()
        {
            return Ok("This is public data. No authentication required.");
        }

        // Protected endpoint - accessible to authenticated users
        [HttpGet("protected")]
        [Authorize]
        public IActionResult GetProtectedData()
        {
            return Ok("This is protected data. You are authenticated.");
        }

        // Admin-only endpoint - accessible only to users with the 'admin' role
        [HttpGet("admin/protected")]
        [Authorize(Roles = "admin")]
        public IActionResult GetAdminProtectedData()
        {
            return Ok("This is protected data for admin users.");
        }
    }
}
