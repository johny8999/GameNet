using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Domain.Models;
namespace Infra.Data.Repositories.Users;

public interface IUserRepository
{
  Task<IdentityResult> AddAsync(Domain.Models.Users entity, string password);
  Task<IdentityResult> AddToRolesAsync(Domain.Models.Users user, IEnumerable<string> roles);
  Task<IdentityResult> ConfirmEmailAsync(Domain.Models.Users user, string token);
  Task<Domain.Models.Users> FindByEmailAsync(string email);
  Task<Domain.Models.Users> FindByIdAsync(string userId);
  Task<string> GenerateEmailConfirmationTokenAsync(Domain.Models.Users user);
  Task<string> GeneratePasswordResetTokenAsync(Domain.Models.Users user);
  Task<IList<string>> GetRolesAsync(Domain.Models.Users user);
  Task<SignInResult> PasswordSignInAsync(Domain.Models.Users user, string password, bool isPersistent, bool lockoutOnFailure);
  Task<IdentityResult> RemoveFromRolesAsync(Domain.Models.Users user, IEnumerable<string> roles);
  Task<IdentityResult> ResetPasswordAsync(Domain.Models.Users user, string token, string newPassword);
}
