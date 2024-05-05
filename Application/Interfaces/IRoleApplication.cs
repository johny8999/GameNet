using Application.Dto.Role.Request;

namespace Application.Interfaces;

public interface IRoleApplication
{
  Task<List<string>> GetRoleNameByUserIdAsync(GetRoleNameByUserIdDto input);
}
