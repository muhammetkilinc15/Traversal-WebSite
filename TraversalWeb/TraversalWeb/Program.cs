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




// Burada Identity Yapýlandýrmasýsýný yapýyoruz
builder.Services.AddDbContext<Context>();                                           // Custom ýdentity erroru kullandýk(Hatalarý Türkçe yaptýk)
builder.Services.AddIdentity<AppUser, AppRole>()
	.AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>();
// buraya kadar kýsým


builder.Services.AddControllersWithViews();

// ====>  Authorization için gerekli kýsým
builder.Services.AddMvc(config =>
{
	var policy = new AuthorizationPolicyBuilder()
	.RequireAuthenticatedUser()
	.Build();
	config.Filters.Add(new AuthorizeFilter());
});


//---->>> Dependency Injection için 
Extensions.ContainerDependencies(builder.Services);
// <<<<<<------------------------

builder.Services.AddMvc();

// Buraya kadar <=======

var app = builder.Build();

// <<<<------- Loging iþlemleri burada yapýldý ******* 
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






// Hata alýndýðý zaman istediðimiz sayfalara yönlendireðiz
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/","?code{0}");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication(); /// Authenticatie için kendimiz yazýyoruz

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
