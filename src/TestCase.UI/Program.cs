using Autofac;
using Autofac.Extensions.DependencyInjection;
using TestCase.Container;
using TestCase.Container.Modules;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
RepositoryModule.AddDbContext(builder.Services, builder.Configuration);
builder.Services.AddControllersWithViews();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    Bootstrapper.RegisterModules(builder);
});
var app = builder.Build();

var container = app.Services.GetAutofacRoot();
Bootstrapper.SetContainer(container);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Order}/{action=Index}/{id?}");

app.Run();