using Microsoft.AspNetCore.Identity;

namespace Application.Authentication.Identity;

public class CustomErrorDescriber : IdentityErrorDescriber
{
  public override IdentityError DefaultError()
  {
    return new IdentityError
      { Code = nameof(DefaultError), Description = "خطایی ناشناخته رخ داد. لطفا بعدا مجدد امتحان کنید" };
  }

  public override IdentityError ConcurrencyFailure()
  {
    return new IdentityError
    {
      Code = nameof(ConcurrencyFailure),
      Description = "رکورد جاری پیشتر ویرایش شده‌است و تغییرات شما آن ‌را بازنویسی خواهد کرد"
    };
  }

  public override IdentityError PasswordMismatch()
  {
    return new IdentityError { Code = nameof(PasswordMismatch), Description = "کلمه عبور صحیح نمیباشد" };
  }

  public override IdentityError InvalidToken()
  {
    return new IdentityError
    {
      Code = nameof(InvalidToken),
      Description = "اطلاعات ارسالی صحیح نیست. لطفا روی لینک موجود در ایمیل کلیک کنید و آدرس ایمیل را نیز مجددا چک کنید"
    };
  }

  public override IdentityError LoginAlreadyAssociated()
  {
    return new IdentityError { Code = nameof(LoginAlreadyAssociated), Description = "این کاربر قبلأ لاگین شده‌است" };
  }

  public override IdentityError InvalidUserName(string userName)
  {
    return new IdentityError
    {
      Code = nameof(InvalidUserName),
      Description = $"نام کاربری '{userName}' نامعتبر است، فقط می تواند حاوی حروف و یا اعداد باشد"
    };
  }

  public override IdentityError InvalidEmail(string email)
  {
    return new IdentityError { Code = nameof(InvalidEmail), Description = "ایمیل '{email}' نامعتبر است" };
  }

  public override IdentityError DuplicateUserName(string userName)
  {
    return new IdentityError
      { Code = nameof(DuplicateUserName), Description = $"نام کاربری '{userName}' تکراری میباشد" };
  }

  public override IdentityError DuplicateEmail(string email)
  {
    return new IdentityError { Code = nameof(DuplicateEmail), Description = $"ایمیل '{email}' تکراری میباشد" };
  }

  public override IdentityError InvalidRoleName(string role)
  {
    return new IdentityError { Code = nameof(InvalidRoleName), Description = $"نام نقش '{role}' معتبر نمیباشد" };
  }

  public override IdentityError DuplicateRoleName(string role)
  {
    return new IdentityError { Code = nameof(DuplicateRoleName), Description = $"نام نقش '{role}' تکراری میباشد" };
  }

  public override IdentityError UserAlreadyHasPassword()
  {
    return new IdentityError
      { Code = nameof(UserAlreadyHasPassword), Description = "کاربر از قبل دارای کلمه عبور می باشد" };
  }

  public override IdentityError UserLockoutNotEnabled()
  {
    return new IdentityError
      { Code = nameof(UserLockoutNotEnabled), Description = "این کاربر قفل نشده است و فعال می باشد" };
  }

  public override IdentityError UserAlreadyInRole(string role)
  {
    return new IdentityError
      { Code = nameof(UserAlreadyInRole), Description = $"کاربر از قبل عضو نقش '{role}' می باشد" };
  }

  public override IdentityError UserNotInRole(string role)
  {
    return new IdentityError { Code = nameof(UserNotInRole), Description = "کاربر عضو این Role نمیباشد" };
  }

  public override IdentityError PasswordTooShort(int length)
  {
    return new IdentityError
      { Code = nameof(PasswordTooShort), Description = $"کلمه عبور باید حداقل {length} کاراکتر باشد" };
  }

  public override IdentityError PasswordRequiresNonAlphanumeric()
  {
    return new IdentityError
    {
      Code = nameof(PasswordRequiresNonAlphanumeric),
      Description = "کلمه عبور باید حداقل یک کاراکتر از حروف الفبا داشته باشد"
    };
  }

  public override IdentityError PasswordRequiresDigit()
  {
    return new IdentityError
      { Code = nameof(PasswordRequiresDigit), Description = "کلمه عبور باید حداقل یک عدد داشته باشد" };
  }

  public override IdentityError PasswordRequiresLower()
  {
    return new IdentityError
      { Code = nameof(PasswordRequiresLower), Description = "کلمه عبور باید حداقل یک حروف کوچک داشته باشد" };
  }

  public override IdentityError PasswordRequiresUpper()
  {
    return new IdentityError
      { Code = nameof(PasswordRequiresUpper), Description = "کلمه عبور باید حداقل یک حروف بزرگ داشته باشد" };
  }

  public override IdentityError RecoveryCodeRedemptionFailed()
  {
    return new IdentityError { Code = nameof(RecoveryCodeRedemptionFailed), Description = "بازیابی ناموفق بود" };
  }

  public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
  {
    return new IdentityError
    {
      Code = nameof(PasswordRequiresUniqueChars),
      Description = $"کلمه‌ی عبور باید حداقل داراى {uniqueChars} حرف متفاوت باشد"
    };
  }
}
