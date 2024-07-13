using Application.Dto.UserRole.Request;
using Infra.Data.Repositories.Roles;
using Infra.Data.Repositories.UserRole;
using Infra.Data.Repositories.Users;

namespace Application.Services;

public class UserRoleApplication(
  IUserRepository userRepository,
  IResponse response,
  ISerilogger serilogger,
  IRoleRepository roleRepository,
  IServiceProvider serviceProvider,
  IUserRoleRepository repository) : IUserRoleApplication
{
  public async Task<ResponseDto> ChangeUserRoleAsync(ChangeUserRole input)
  {
    try
    {
      #region Validation

      input.CheckModelState(serviceProvider);

      #endregion

      #region userCheking

      {
        var userChek = await userRepository.GetNoTraking
          .AnyAsync(a => a.Id == input.UserId.ToGuid());

        if (userChek is false)
        {
          return response.GenerateResponse(HttpStatusCode.BadRequest,
            ReturnMessages.NotExist("کاربر"));
        }
      }

      #endregion userCheking

      #region roleCheking

      {
        var roleChek = await roleRepository.GetNoTraking
          .AnyAsync(a => a.Id == input.OldRoleId.ToGuid());

        if (roleChek is false)
        {
          return response.GenerateResponse(HttpStatusCode.BadRequest,
            ReturnMessages.NotExist("نقش"));
        }
      }

      #endregion roleCheking

      #region Update Role

      {
        var userRole = await repository.Get.SingleOrDefaultAsync(a => a.RoleId == input.OldRoleId.ToGuid() &&
                                                                      a.UserId == input.UserId.ToGuid());
        if (userRole is not null)
        {
          var deleteUserRole = await repository.ReturnDeleteAsync(userRole);
          if (deleteUserRole)
          {
            await repository.AddAsync(new TblUserRole
            {
              RoleId = input.NewRoleId.ToGuid(),
              UserId = input.UserId.ToGuid()
            });
            return response.GenerateResponse(HttpStatusCode.OK,
              ReturnMessages.SuccessfulUpdate("نقش"));
          }
        }

        return response.GenerateResponse(HttpStatusCode.OK,
          ReturnMessages.GeneralPrint(
            "نقش مورد نظر به کاربر اختصاص داده نشده است ابتدا باید به کاربر مورد نظر نقش داده شود"));
      }

      #endregion Update Role
    }
    catch (ArgumentException ex)
    {
      serilogger.Debug(ex.Message);
      return response.GenerateResponse(HttpStatusCode.BadRequest,
        ReturnMessages.GeneralPrint(ex.Message));
    }

    catch (Exception ex)
    {
      serilogger.Error(ex);
      return response.GenerateResponse(HttpStatusCode.InternalServerError,
        ReturnMessages.GeneralPrint("خطایی رخ داد"));
    }
  }

  public async Task<ResponseDto> AddUserRoleAsync(AddUserRoleDto input)
  {
    try
    {
      #region Validation

      input.CheckModelState(serviceProvider);

      #endregion

      #region userCheking

      {
        var userChek = await userRepository.GetNoTraking
          .AnyAsync(a => a.Id == input.UserId.ToGuid());

        if (userChek is false)
        {
          return response.GenerateResponse(HttpStatusCode.BadRequest,
            ReturnMessages.NotExist("کاربر"));
        }
      }

      #endregion userCheking

      #region roleCheking

      {
        var roleChek = await roleRepository.GetNoTraking
          .AnyAsync(a => a.Id == input.RoleId.ToGuid());

        if (roleChek is false)
        {
          return response.GenerateResponse(HttpStatusCode.BadRequest,
            ReturnMessages.NotExist("نقش"));
        }
      }

      #endregion roleCheking

      #region Cheking Doplicate Role and User

      {
        var doplicate = await repository.GetNoTraking
          .AnyAsync(a => a.RoleId == input.RoleId.ToGuid()
                                     && a.UserId == input.UserId.ToGuid());
        if (doplicate )
        {
          return response.GenerateResponse(HttpStatusCode.BadRequest,
            ReturnMessages.Douplicate("نقش و کاربر"));
        }

      }
      #endregion Cheking Doplicate Role and User

      #region Add Role

      {
        var userRole = input.Adapt<TblUserRole>();
        if (await repository.ReturnAddAsync(userRole))
          return response.GenerateResponse(HttpStatusCode.OK,
            ReturnMessages.SuccessfulAdd("نقش"));

        return response.GenerateResponse(HttpStatusCode.BadRequest,
          ReturnMessages.FailedAdd("نقش"));
      }

      #endregion Add Role
    }
    catch (ArgumentException ex)
    {
      serilogger.Debug(ex.Message);
      return response.GenerateResponse(HttpStatusCode.BadRequest,
        ReturnMessages.GeneralPrint(ex.Message));
    }

    catch (Exception ex)
    {
      serilogger.Error(ex);
      return response.GenerateResponse(HttpStatusCode.InternalServerError,
        ReturnMessages.GeneralPrint("خطایی رخ داد"));
    }
  }
}
