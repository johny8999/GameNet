using Application.Common.Statics;
using Application.Dto.Users;
using Application.Dto.Users.Request;

namespace Application.Interfaces;

public interface IUserApplication
{
  // Task<ResponseDto> ChangeEmailAsync(InpChangeEmail Input);
  // Task<ResponseDto> ChangeUserAccLevelAsync(InpChangeUserAccLevel Input);
  // Task<ResponseDto> CheckRegisterUserAsync(InpCheckRegisterUser Input);
  Task<ResponseDto> GetAllUserDetailsAsync(InpGetAllUserDetails input);
  // Task<ResponseDto> GetListUsersForManageAsync(InpGetListUsersForManage Input);
  // Task<ResponseDto> GetUserDetailsForAccountSettingAsync(InpGetUserDetailsForAccountSetting Input);
  // Task<ResponseDto> GetUserForEditProfileAsync(InpGetUserForEditProfile Input);
  // Task<ResponseDto> LoginAsync(InpLogin Input);
  // Task<ResponseDto> LoginOtpAsync(InpLoginOtp Input);
  // Task<ResponseDto> RegisterAsync(string PhoneNumber);
  // Task<ResponseDto> ResendSmsCodeAsync(InpResendSmsCode Input);
  // Task<ResponseDto> SaveAccountDetailsAsync(InpSaveAccountDetails Input);
}
