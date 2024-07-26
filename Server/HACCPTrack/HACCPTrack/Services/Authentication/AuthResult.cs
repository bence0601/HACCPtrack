namespace HACCPTrack.Services.Authentication
{
    public record AuthResult(
        bool Success,
        string IdentityUserId,
        string Email,
        string UserName,
        string Role,
        string Token)
    {
        //Error code - error message
        public readonly Dictionary<string, string> ErrorMessages = new();
    }
}
