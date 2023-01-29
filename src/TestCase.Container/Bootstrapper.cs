using Autofac;
using TestCase.Container.Modules;

namespace TestCase.Container;

public class Bootstrapper
{
    public static ILifetimeScope Container { get; private set; }

    public static void RegisterModules(ContainerBuilder containerBuilder)
    {
        containerBuilder.RegisterModule(new MediatRModule());
        containerBuilder.RegisterModule(new RepositoryModule());
    }

    public static void SetContainer(ILifetimeScope autofacContainer)
    {
        Container = autofacContainer;
    }
}