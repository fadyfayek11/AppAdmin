using MarminaAttendance.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<StaticFileOptions>(options =>
{
	options.ServeUnknownFileTypes = true; 
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{

    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
    options.ClaimsIdentity.UserIdClaimType = "UserID";
}).AddEntityFrameworkStores<IdentityContext>().AddDefaultUI().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/Login");


var app = builder.Build();

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
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapRazorPages();
app.UseEndpoints(endpoints =>
{

    endpoints.MapControllerRoute(
        name: "admin",
        pattern: "admin/{action}/{id?}",
        defaults: new { controller = "Admins" }); 
    endpoints.MapControllerRoute(
        name: "admin",
        pattern: "admin/{action}/{admin?}",
        defaults: new { controller = "Admins" });
    
    endpoints.MapControllerRoute(
        name: "news",
        pattern: "news/{action}/{id?}",
        defaults: new { controller = "News" }); 
    endpoints.MapControllerRoute(
        name: "news",
        pattern: "news/{action}/{news?}",
        defaults: new { controller = "News" });
});

app.Run();
