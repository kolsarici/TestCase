namespace TestCase.Domain;

public interface IDbContextHandler
{
    Task SaveChangesAsync();
}