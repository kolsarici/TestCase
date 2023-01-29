using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestCase.Repository;
using TestCase.Repository.RepositoryAggregate;
using System.Reflection;
using Module = Autofac.Module;

namespace TestCase.Container.Modules;

public class RepositoryModule : Module
{
    private static string? _connectionString;
    
    public static void AddDbContext(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        _connectionString = configuration["DbConnString"];
        serviceCollection.AddEntityFrameworkSqlServer().AddDbContext<TestCaseDbContext>(options => options.UseSqlServer(_connectionString));
    }
    
    protected override void Load(ContainerBuilder builder)
    {
        var assemblyType = typeof(OrderRepository).GetTypeInfo();

        builder.RegisterAssemblyTypes(assemblyType.Assembly)
            .Where(x => x != typeof(TestCaseDbContext))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        base.Load(builder);
    }
}