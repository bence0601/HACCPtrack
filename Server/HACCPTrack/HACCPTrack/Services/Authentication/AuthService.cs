using HACCPTrack.Data;
using HACCPTrack.Models;
using HACCPTrack.Services.InviteLinks;
using Microsoft.AspNetCore.Identity;

namespace HACCPTrack.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;
        private readonly IInviteService _inviteService;
        private readonly DataContext _dataContext;

        public AuthService(UserManager<IdentityUser> userManager, ITokenService tokenService, IInviteService inviteService, DataContext dataContext, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _inviteService = inviteService;
            _dataContext = dataContext;
            _roleManager = roleManager;
        }

        public async Task<AuthResult> RegisterAsync(string email, string username, string password, string inviteCode)
        {
            // Ellenőrizzük a meghívókódot
            var role = await _inviteService.ValidateInviteAsync(inviteCode);
            var identityRole = await _roleManager.FindByNameAsync(role);
            if (identityRole == null)
            {
                return FailedRegistration(email, username, "Role not found.");
            }

            if (string.IsNullOrEmpty(role))
            {
                return FailedRegistration(email, username, "Invalid or expired invite code.");
            }

            // Létrehozzuk a felhasználót
            var identityUser = new IdentityUser { UserName = username, Email = email };

            var result = await _userManager.CreateAsync(identityUser, password);

            if (!result.Succeeded)
            {
                return FailedRegistration(result, email, username);
            }

            // Hozzáadjuk a felhasználót a szerephez
            var user = new User
            {
                IdentityUserId = identityUser.Id,
                Role = role,
                RestaurantId = null,
            };


            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();

            return new AuthResult(true, identityUser.Id, email, username, "");
        }

        public async Task<AuthResult> LoginAsync(string email, string password)
        {
            var managedUser = await _userManager.FindByEmailAsync(email);

            if (managedUser == null)
            {
                return InvalidEmail(email);
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, password);
            if (!isPasswordValid)
            {
                return InvalidPassword(email, managedUser.UserName);
            }

            var accessToken = _tokenService.CreateToken(managedUser);

            return new AuthResult(true, managedUser.Id, managedUser.Email, managedUser.UserName, accessToken);
        }

        private static AuthResult InvalidEmail(string email)
        {
            var result = new AuthResult(false, null, email, "", "");
            result.ErrorMessages.Add("Bad credentials", "Invalid email");
            return result;
        }

        private static AuthResult InvalidPassword(string email, string userName)
        {
            var result = new AuthResult(false, null, email, userName, "");
            result.ErrorMessages.Add("Bad credentials", "Invalid password");
            return result;
        }
        private static AuthResult FailedRegistration(string email, string username, string errorMessage)
        {
            var authResult = new AuthResult(false, null, email, username, "");
            authResult.ErrorMessages.Add("RegistrationError", errorMessage);
            return authResult;
        }
        private static AuthResult FailedRegistration(IdentityResult result, string email, string username)
        {
            var authResult = new AuthResult(false, null, email, username, "");

            foreach (var error in result.Errors)
            {
                authResult.ErrorMessages.Add(error.Code, error.Description);
            }

            return authResult;
        }
    }
}
