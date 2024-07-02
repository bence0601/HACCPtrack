using Microsoft.AspNetCore.Identity;

namespace HACCPTrack.Services.Authentication
{
    public interface ITokenService
    {
        public string CreateToken(IdentityUser user);
    }
}
