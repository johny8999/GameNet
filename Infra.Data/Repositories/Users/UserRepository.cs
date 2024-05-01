using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.MainModel;
using Infra.Data.Context;
using Microsoft.AspNetCore.Identity;

namespace Infra.Data.Repositories.Users;

public class UserRepository : BaseModel, IUserRepository
{
  private readonly UserManager<Domain.Models.Users> _userManager;
  private readonly SignInManager<Domain.Models.Users> _signInManager;

  public UserRepository(ApplicationContext context, UserManager<Domain.Models.Users> userManager
    , SignInManager<Domain.Models.Users> signInManager)
  {
    _userManager = userManager;
    _signInManager = signInManager;
  }

  public async Task<IdentityResult> AddAsync(Domain.Models.Users entity, string password)
  {
    return await _userManager.CreateAsync(entity, password);
  }

  public async Task<IdentityResult> AddToRolesAsync(Domain.Models.Users user, IEnumerable<string> roles)
  {
    return await _userManager.AddToRolesAsync(user, roles);
  }

  public async Task<IdentityResult> ConfirmEmailAsync(Domain.Models.Users user, string token)
  {
    return await _userManager.ConfirmEmailAsync(user, token);
  }

  public async Task<Domain.Models.Users> FindByEmailAsync(string email)
  {
    return await _userManager.FindByEmailAsync(email);
  }

  public async Task<Domain.Models.Users> FindByIdAsync(string userId)
  {
    return await _userManager.FindByIdAsync(userId);
  }

  public async Task<string> GenerateEmailConfirmationTokenAsync(Domain.Models.Users user)
  {
    return await _userManager.GenerateConcurrencyStampAsync(user);
  }

  public async Task<string> GeneratePasswordResetTokenAsync(Domain.Models.Users user)
  {
    return await _userManager.GeneratePasswordResetTokenAsync(user);
  }

  public async Task<IList<string>> GetRolesAsync(Domain.Models.Users user)
  {
    return await _userManager.GetRolesAsync(user);
  }

  public async Task<SignInResult> PasswordSignInAsync(Domain.Models.Users user, string password, bool isPersistent,
    bool lockoutOnFailure)
  {
    return await _signInManager.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);
  }

  public async Task<IdentityResult> RemoveFromRolesAsync(Domain.Models.Users user, IEnumerable<string> roles)
  {
    // واکشی رول های فعلی کاربر
    var qRoles = await _userManager.GetRolesAsync(user);

    // حذف عضویت
    return await _userManager.RemoveFromRolesAsync(user, qRoles);
  }

  public async Task<IdentityResult> ResetPasswordAsync(Domain.Models.Users user, string token, string newPassword)
  {
    return await _userManager.ResetPasswordAsync(user, token, newPassword);
  }
}
