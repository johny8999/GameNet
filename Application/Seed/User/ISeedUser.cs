namespace Application.Seed.User;

public interface ISeedUser
{
  Task<bool> RunAsync();
}
