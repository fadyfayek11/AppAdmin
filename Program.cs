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
		name: "homeRoot",
		pattern: "Home",
		defaults: new { controller = "Home", action = "Index" });

	endpoints.MapControllerRoute(
		name: "home",
		pattern: "home/{action}/{id?}",
		defaults: new { controller = "Home" });

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
    
    endpoints.MapControllerRoute(
        name: "cms",
        pattern: "cms/{action}/{id?}",
        defaults: new { controller = "CMS" }); 
    endpoints.MapControllerRoute(
        name: "cms",
        pattern: "cms/{action}/{cms?}",
        defaults: new { controller = "CMS" }); 
    
    endpoints.MapControllerRoute(
        name: "room",
        pattern: "room/{action}/{id?}",
        defaults: new { controller = "Rooms" }); 
    endpoints.MapControllerRoute(
        name: "room",
        pattern: "room/{action}/{room?}",
        defaults: new { controller = "Rooms" });
    
    endpoints.MapControllerRoute(
        name: "reservation",
        pattern: "reservation/{action}/{id?}",
        defaults: new { controller = "Reservations" }); 
    endpoints.MapControllerRoute(
        name: "reservation",
        pattern: "reservation/{action}/{reservation?}",
        defaults: new { controller = "Reservations" });
    
    endpoints.MapControllerRoute(
        name: "testimonies",
        pattern: "testimonies/{action}/{id?}",
        defaults: new { controller = "Testimonies" }); 
    endpoints.MapControllerRoute(
        name: "testimonies",
        pattern: "testimonies/{action}/{testimonies?}",
        defaults: new { controller = "Testimonies" });
    
    endpoints.MapControllerRoute(
        name: "roomDetails",
        pattern: "roomDetails/{action}/{id?}",
        defaults: new { controller = "RoomDetails" }); 
    endpoints.MapControllerRoute(
        name: "roomDetails",
        pattern: "roomDetails/{action}/{details?}",
        defaults: new { controller = "RoomDetails" });
    
    endpoints.MapControllerRoute(
        name: "roomImages",
        pattern: "roomImages/{action}/{id?}",
        defaults: new { controller = "RoomImages" }); 
    endpoints.MapControllerRoute(
        name: "roomImages",
        pattern: "roomImages/{action}/{images?}",
        defaults: new { controller = "RoomImages" });
});

app.Run();
