using System.ComponentModel.DataAnnotations;
using FrameWork.DataAnnotations.String;

namespace Application.Dto;

public sealed class RegisterDTo
{
  [RequiredString] [EmailTempl] public string Email { get; set; }
  [RequiredString] public string FirstName { get; set; }
  [RequiredString] public string LastName { get; set; }
  [RequiredString] public string Password { get; set; }
  [RequiredString] public string NationalCode { get; set; }

  [RequiredString] [Compare("Password")] public string PasswordConfirm { get; set; }
}
