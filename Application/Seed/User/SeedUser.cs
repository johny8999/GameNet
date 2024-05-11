using Domain.Models;
using FrameWork.Exceptions;
using FrameWork.ExMethods;
using Infra.Data.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Seed.User;

public class SeedUser : ISeedUser
{
  private readonly IUserRepository _userRepository;

  public SeedUser(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  public async Task<bool> RunAsync()
  {
    try
    {
      #region Admin

      {
        if (!await _userRepository.GetNoTraking.AnyAsync(a => a.Email == "Sinaalipour89@gmail.com"))
          await _userRepository.AddAsync(new TblUsers()
          {
            Id = "ef23660b-8344-4243-8276-576845a1b262".ToGuid(),
            FirstName = "Admin",
            LastName = "Admin",
            Email = "Sinaalipour89@gmail.com",
            PhoneNumber = "09133802351",
            NationalCode = "4610248603",
            UserName = "Sinaalipour89@gmail.com",
            PhoneNumberConfirmed = true,
            EmailConfirmed = true,
          });
      }

      #endregion Admin

      return true;
    }
    catch (ArgumentInvalidException ex)
    {
      // _Logger.Debug(ex);
      return default; //false
    }
    catch (Exception ex)
    {
      // _Logger.Error(ex);
      return default;
    }
  }
}
