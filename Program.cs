using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ONP2023_Project.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ONP2023_ProjectContextConnection") ?? throw new InvalidOperationException("Connection string 'ONP2023_ProjectContextConnection' not found.");

builder.Services.AddDbContext<ONP2023_ProjectContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AllUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ONP2023_ProjectContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
