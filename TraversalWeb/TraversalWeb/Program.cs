using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using BusinessLayer.Container;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using TraversalWeb.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddLogging(X =>
{
	X.ClearProviders();
	X.SetMinimumLevel(LogLevel.Debug);
	X.AddDebug();
});




// Burada Identity Yap�land�rmas�s�n� yap�yoruz
builder.Services.AddDbContext<Context>();                                           // Custom �dentity erroru kulland�k(Hatalar� T�rk�e yapt�k)
builder.Services.AddIdentity<AppUser, AppRole>()
	.AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>();
// buraya kadar k�s�m


builder.Services.AddControllersWithViews();

// ====>  Authorization i�in gerekli k�s�m
builder.Services.AddMvc(config =>
{
	var policy = new AuthorizationPolicyBuilder()
	.RequireAuthenticatedUser()
	.Build();
	config.Filters.Add(new AuthorizeFilter());
});


//---->>> Dependency Injection i�in 
Extensions.ContainerDependencies(builder.Services);
// <<<<<<------------------------

builder.Services.AddMvc();

// Buraya kadar <=======

var app = builder.Build();

// <<<<------- Loging i�lemleri burada yap�ld� ******* 
ILoggerFactory loggerFactory = new LoggerFactory();
var path = Directory.GetCurrentDirectory();
loggerFactory.AddFile($"{path}\\Logs\\Log1.txt");


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}






// Hata al�nd��� zaman istedi�imiz sayfalara y�nlendire�iz
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/","?code{0}");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication(); /// Authenticatie i�in kendimiz yaz�yoruz

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Login}/{action=SingIn}/{id?}");

app.MapControllerRoute(
	  name: "areas",
	  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
	);


app.MapControllerRoute(
	  name: "areas",
	  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
	);

app.Run();
