using HACCPTrack.Data;
using HACCPTrack.Models.Invites;
using Microsoft.EntityFrameworkCore;

namespace HACCPTrack.Services.InviteLinks
{
    public class InviteService : IInviteService
    {
        private readonly DataContext _context;

        public InviteService(DataContext context)
        {
            _context = context;
        }

        public async Task<string> GenerateInviteAsync(string role)
        {
            var inviteCode = Guid.NewGuid().ToString();
            var invite = new Invite
            {
                Code = inviteCode,
                Role = role,
                CreatedAt = DateTime.UtcNow,
                IsUsed = false
            };
            _context.Invites.Add(invite);
            await _context.SaveChangesAsync();
            return inviteCode;
        }

        public async Task<string> ValidateInviteAsync(string inviteCode)
        {
            var invite = await _context.Invites
                .Where(i => i.Code == inviteCode && !i.IsUsed)
                .FirstOrDefaultAsync();
            if (invite != null)
            {
                invite.IsUsed = true;
                await _context.SaveChangesAsync();
                return invite.Role;
            }
            return null;
        }
    }
}
