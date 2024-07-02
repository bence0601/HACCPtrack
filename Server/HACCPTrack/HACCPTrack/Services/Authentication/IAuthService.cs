namespace HACCPTrack.Services.Authentication
{
    public interface IAuthService
    {
        Task<AuthResult> RegisterAsync(string email, string username, string password, string inviteCode);
        Task<AuthResult> LoginAsync(string email, string password);
    }
}
