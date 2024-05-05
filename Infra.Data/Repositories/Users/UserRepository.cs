using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Data.Context;
using Microsoft.AspNetCore.Identity;

namespace Infra.Data.Repositories.Users;

public class UserRepository : Repository<TblUsers>, IUserRepository
{
  private readonly UserManager<TblUsers> _userManager;
  private readonly SignInManager<TblUsers> _signInManager;

  public UserRepository(MainContext context, UserManager<TblUsers> userManager
    , SignInManager<TblUsers> signInManager) : base(context)
  {
    _userManager = userManager;
    _signInManager = signInManager;
  }

  public async Task<IdentityResult> AddAsync(Domain.Models.TblUsers entity, string password)
  {
    return await _userManager.CreateAsync(entity, password);
  }

  public async Task<IdentityResult> CreateUserAsync(TblUsers User)
  {
    return await _userManager.CreateAsync(User);
  }

  public async Task<IdentityResult> AddToRolesAsync(Domain.Models.TblUsers tblUser, IEnumerable<string> roles)
  {
    return await _userManager.AddToRolesAsync(tblUser, roles);
  }

  public async Task<IdentityResult> ConfirmEmailAsync(Domain.Models.TblUsers tblUser, string token)
  {
    return await _userManager.ConfirmEmailAsync(tblUser, token);
  }

  public async Task<Domain.Models.TblUsers> FindByEmailAsync(string email)
  {
    return await _userManager.FindByEmailAsync(email);
  }

  public async Task<Domain.Models.TblUsers> FindByIdAsync(string userId)
  {
    return await _userManager.FindByIdAsync(userId);
  }

  public async Task<string> GenerateEmailConfirmationTokenAsync(Domain.Models.TblUsers tblUser)
  {
    return await _userManager.GenerateConcurrencyStampAsync(tblUser);
  }

  public async Task<string> GeneratePasswordResetTokenAsync(Domain.Models.TblUsers tblUser)
  {
    return await _userManager.GeneratePasswordResetTokenAsync(tblUser);
  }

  public async Task<IList<string>> GetRolesAsync(Domain.Models.TblUsers tblUser)
  {
    return await _userManager.GetRolesAsync(tblUser);
  }

  public async Task<SignInResult> PasswordSignInAsync(Domain.Models.TblUsers tblUser, string password,
    bool isPersistent,
    bool lockoutOnFailure)
  {
    return await _signInManager.PasswordSignInAsync(tblUser, password, isPersistent, lockoutOnFailure);
  }

  public async Task<IdentityResult> RemoveFromRolesAsync(Domain.Models.TblUsers tblUser, IEnumerable<string> roles)
  {
    // واکشی رول های فعلی کاربر
    var qRoles = await _userManager.GetRolesAsync(tblUser);

    // حذف عضویت
    return await _userManager.RemoveFromRolesAsync(tblUser, qRoles);
  }

  public async Task<IdentityResult> ResetPasswordAsync(Domain.Models.TblUsers tblUser, string token, string newPassword)
  {
    return await _userManager.ResetPasswordAsync(tblUser, token, newPassword);
  }
}
