namespace Application.Seed.Entity;

public interface ISeedEntity
{
  Task<bool> RunAsync();
}
