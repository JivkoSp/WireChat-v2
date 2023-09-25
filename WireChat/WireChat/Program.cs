using Microsoft.AspNetCore.Identity;
using WireChat.Application.Extensions;
using WireChat.Infrastructure.EntityFramework.Contexts;
using WireChat.Infrastructure.EntityFramework.Models;
using WireChat.Infrastructure.Extensions;
using WireChat.Infrastructure.SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddIdentity<UserReadModel, IdentityRole>(opt =>
{
    opt.Password.RequiredLength = 4;
    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireNonAlphanumeric = false;
    opt.SignIn.RequireConfirmedAccount = true;
    opt.SignIn.RequireConfirmedEmail = true;

}).AddEntityFrameworkStores<ReadDbContext>().AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<ChatHub>("/chatHub");

app.MapHub<ContactHub>("/contactHub");

app.Run();
