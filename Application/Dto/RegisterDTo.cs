using System.ComponentModel.DataAnnotations;
using FrameWork.DataAnnotations.String;

namespace Application.Dto;

public sealed class RegisterDTo
{
  [RequiredString] [EmailAddress] public string Email { get; set; }
  [RequiredString] public string FirstName { get; set; }
  [RequiredString] public string LastName { get; set; }
}
