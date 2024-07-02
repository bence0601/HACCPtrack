namespace HACCPTrack.Services.InviteLinks
{
    public interface IInviteService
    {
        Task<string> GenerateInviteAsync(string role, string? restaurantId = null);
        Task<string> ValidateInviteAsync(string inviteCode);
    }
}
