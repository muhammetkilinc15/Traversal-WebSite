using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using BusinessLayer.Container;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concreate;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using TraversalWeb.CQRS.Handlers.DestinationHandlers;
using TraversalWeb.Models;

var builder = WebApplication.CreateBuilder(args);
// ----->>>> CQRS i�in 
builder.Services.AddScoped<GetAllDestinationQueryHandler>();
builder.Services.AddScoped<GetDestinationIdQeueryHandler>();
builder.Services.AddScoped<CreateDestinationCommandHandler>();
builder.Services.AddScoped<RemoveDestinationCommandHandler>();
builder.Services.AddScoped<UpdateDestinationHandler>();

// <<<<<<------------

builder.Services.AddLogging(X =>
{
    X.ClearProviders();
    X.SetMinimumLevel(LogLevel.Debug);
    X.AddDebug();
});


// <<<<<<<<<<<< API ye ba�lanmak i�in
builder.Services.AddHttpClient();


// Burada Identity Yap�land�rmas�s�n� yap�yoruz
builder.Services.AddDbContext<Context>();                                           // Custom �dentity erroru kulland�k(Hatalar� T�rk�e yapt�k)
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>();
// buraya kadar k�s�m


// ---->>>>>>  Automapper i�in gereklli servis eklendi 
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.CustomerValidator();

// <<<<<<-------


// >>>>>>>>>>>>>>>>>>>> sonuna addFluentValidation() ekledik
builder.Services.AddControllersWithViews().AddFluentValidation();

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
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/", "?code{0}");

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
