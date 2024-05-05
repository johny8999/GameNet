using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Domain.Models;
namespace Infra.Data.Repositories.Users;

public interface IUserRepository:IRepository<TblUsers>
{
  Task<IdentityResult> AddAsync(Domain.Models.TblUsers entity, string password);
  Task<IdentityResult> AddToRolesAsync(Domain.Models.TblUsers tblUser, IEnumerable<string> roles);
  Task<IdentityResult> ConfirmEmailAsync(Domain.Models.TblUsers tblUser, string token);
  Task<Domain.Models.TblUsers> FindByEmailAsync(string email);
  Task<Domain.Models.TblUsers> FindByIdAsync(string userId);
  Task<string> GenerateEmailConfirmationTokenAsync(Domain.Models.TblUsers tblUser);
  Task<string> GeneratePasswordResetTokenAsync(Domain.Models.TblUsers tblUser);
  Task<IList<string>> GetRolesAsync(Domain.Models.TblUsers tblUser);
  Task<SignInResult> PasswordSignInAsync(Domain.Models.TblUsers tblUser, string password, bool isPersistent, bool lockoutOnFailure);
  Task<IdentityResult> RemoveFromRolesAsync(Domain.Models.TblUsers tblUser, IEnumerable<string> roles);
  Task<IdentityResult> ResetPasswordAsync(Domain.Models.TblUsers tblUser, string token, string newPassword);
  Task<IdentityResult> CreateUserAsync(TblUsers User);
}
