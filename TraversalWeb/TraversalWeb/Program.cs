using DataAccessLayer.Concreate;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using TraversalWeb.Models;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddMvc();

// Buraya kadar <=======

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

app.Run();
