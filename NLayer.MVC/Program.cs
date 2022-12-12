using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entities;
using NLayer.Repository;
using NLayer.Repository.Seeds;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), opt =>
    {
        opt.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

builder.Services.AddIdentityCore<User>(opt =>
{
    opt.User.RequireUniqueEmail = true;
}).AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

// Add services to the container.
builder.Services.AddRazorPages();



var app = builder.Build();

//biri admin biri member 2 kullanýcýnýn oluþturulmasý
using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
try
{
    context.Database.Migrate();
    await DbInitializer.Initialize(userManager);
}
catch (Exception)
{
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
