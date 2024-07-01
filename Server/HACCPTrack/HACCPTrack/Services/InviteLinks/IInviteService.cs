namespace HACCPTrack.Services.InviteLinks
{
    public interface IInviteService
    {
        Task<string> GenerateInviteAsync(string role);
        Task<string> ValidateInviteAsync(string inviteCode);
    }
}
