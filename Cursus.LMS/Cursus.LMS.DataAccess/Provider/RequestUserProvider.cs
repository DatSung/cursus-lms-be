using Cursus.LMS.DataAccess.IProvider;
using Cursus.LMS.Model.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursus.LMS.DataAccess.Provider
{
    public class RequestUserProvider : IRequestUserProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        private bool PhoneNumberIsValid(string phoneNumber)
        {
            // Implement your logic to validate phone numbers here
            // For demonstration, assuming any non-empty string is a valid phone number
            return !string.IsNullOrEmpty(phoneNumber);
        }

        public RequestUserProvider(IHttpContextAccessor contextAccessor, UserManager<ApplicationUser> userManager)
        {
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role)
        {
            return await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<bool> IsPhoneNumberExistsAsync(string phoneNumber)
        {
            return await _userManager.Users.AnyAsync(u => u.PhoneNumber == phoneNumber);
        }
        public async Task<ApplicationUser?> FindByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }
        public async Task<IdentityResult> UpdateAsync(ApplicationUser user)
        {
            // Call UserManager's UpdateAsync method to update the user
            var updateResult = await _userManager.UpdateAsync(user);
            return updateResult;
        }
        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            // Call UserManager's CheckPasswordAsync method to check if the password is correct
            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, password);
            return isPasswordCorrect;
        }
        public async Task<IList<string>> GetRolesAsync(ApplicationUser user)
        {
            // Call UserManager's GetRolesAsync method to retrieve the roles of the user
            var roles = await _userManager.GetRolesAsync(user);
            return roles;
        }
        public async Task<ApplicationUser?> FindUserByPhoneNumberOrEmailAsync(string phoneNumberOrEmail)
        {
            // Check if the provided input is a valid phone number
            if (PhoneNumberIsValid(phoneNumberOrEmail))
            {
                // If valid phone number, find user by phone number
                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumberOrEmail);
                return user;
            }
            else
            {
                // If not a valid phone number, assume it's an email and find user by email
                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == phoneNumberOrEmail);
                return user;
            }
        }
        public async Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            return token;
        }
        public async Task<IdentityResult> ResetPasswordAsync(ApplicationUser user, string token, string newPassword)
        {
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            return result;
        }
        public async Task<IdentityResult> ChangePasswordAsync(ApplicationUser user, string oldPassword, string newPassword)
        {
            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            return result;
        }
        public async Task<IdentityResult> ConfirmEmailAsync(ApplicationUser user, string token)
        {
            var result = await _userManager.ConfirmEmailAsync(user, token);
            return result;
        }

    }
}
