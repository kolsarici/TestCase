using TestCase.Domain;

namespace TestCase.Repository;

public class DbContextHandler : IDbContextHandler
{
    private readonly TestCaseDbContext _dbContext;

    public DbContextHandler(TestCaseDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    

    public async Task SaveChangesAsync()
    {
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}