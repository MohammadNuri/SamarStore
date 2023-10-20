using SamarStore.Application.Services.Users.Queries.GetRoles;
using Microsoft.EntityFrameworkCore;
using SamarStore.Application.Interfaces.Context;
using SamarStore.Application.Services.Users.Commands.RegisterUsers;
using SamarStore.Application.Services.Users.Queries.GetUsers;
using SamarStore.Persistence.Context;
using SamarStore.Application.Services.Users.Commands.RemoveUser;
using SamarStore.Application.Services.Users.Commands.UserStatusChange;
using SamarStore.Application.Services.Users.Commands.EditUser;
using SamarStore.Application.Services.Users.Commands.UserLogin;
using Microsoft.AspNetCore.Authentication.Cookies;
using SamarStore.Application.Interfaces.FacadPatterns;
using SamarStore.Application.Services.Products.FacadPattern;
using SamarStore.Application.Services.HomePage.FacadPattern;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();

//--UserServices
builder.Services.AddScoped<IGetUsersService, GetUsersService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();    
builder.Services.AddScoped<IUserStatusChangeService, UserStatusChangeService>(); 
builder.Services.AddScoped<IEditUserService , EditUserService>();   
builder.Services.AddScoped<IUserLoginService, UserLoginService>();  
//--FacadInject
builder.Services.AddScoped<IProductFacad, ProductFacad>();
builder.Services.AddScoped<IProductFacadForSite, ProductFacadForSite>();
builder.Services.AddScoped<IHomePageFacad, HomePageFacad>();


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataBaseContext>(option =>
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
builder.Services.AddAuthentication(options =>
    {
        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    }).AddCookie(options =>
    {
        options.LoginPath = new PathString("/");
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
});



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

app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.Run();
