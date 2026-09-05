using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static System.Net.Mime.MediaTypeNames;
var builder = WebApplication.CreateBuilder(args);

// The preceding code registers ApplicationDbContext, a subclass of DbContext, as a scoped service in the ASP.NET Core app service provider. 
// The service provider is also known as the dependency injection container. 
// The context is configured to use the SQL Server database provider and reads the connection string from ASP.NET Core configuration.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connectio string" + "'DefaultConnection' not found.");
// Add services to the container.
builder.Services.AddControllersWithViews();
//pass to the builder the context of EF Core to use the db

builder.Services.AddDbContext<ApplicationDbContext>(Options =>
    Options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
