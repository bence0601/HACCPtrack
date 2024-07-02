using System.ComponentModel.DataAnnotations;

namespace HACCPTrack.Contracts
{
    public record RegistrationRequest(
        [Required] string Email,
        [Required] string Username,
        [Required] string Password,
        [Required] string InviteCode);
}
