using HACCPTrack.Data;
using HACCPTrack.Models.Invites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HACCPTrack.Services.InviteLinks
{
    public class InviteService : IInviteService
    {
        private readonly DataContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public InviteService(DataContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        public async Task<string> GenerateInviteAsync(string role)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                throw new ArgumentException("Invalid role");
            }

            var inviteCode = Guid.NewGuid().ToString();
            var invite = new Invite
            {
                Code = inviteCode,
                Role = role,
                CreatedAt = DateTime.UtcNow,
                RestaurantId = 0,
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
