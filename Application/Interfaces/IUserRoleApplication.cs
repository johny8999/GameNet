using Application.Dto.UserRole.Request;

namespace Application.Interfaces;

public interface IUserRoleApplication
{
  Task<ResponseDto> ChangeUserRoleAsync(ChangeUserRole input);
}
