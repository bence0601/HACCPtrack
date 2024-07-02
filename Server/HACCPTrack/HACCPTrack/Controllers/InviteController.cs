using HACCPTrack.DTOs;
using HACCPTrack.Services.InviteLinks;
using Microsoft.AspNetCore.Mvc;

namespace HACCPTrack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InviteController : ControllerBase
    {
        private readonly InviteService _inviteService;

        public InviteController(InviteService inviteService)
        {
            _inviteService = inviteService;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateInvite([FromBody] GenerateInviteRequest request, string? restaurantId = null)
        {
            if (string.IsNullOrEmpty(request.Role))
            {
                return BadRequest("Role is required.");
            }

            try
            {
                var inviteCode = await _inviteService.GenerateInviteAsync(request.Role, restaurantId);
                return Ok(new { InviteCode = inviteCode });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }


}
