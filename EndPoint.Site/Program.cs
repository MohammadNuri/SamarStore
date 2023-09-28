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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IGetUsersService, GetUsersService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();    
builder.Services.AddScoped<IUserStatusChangeService, UserStatusChangeService>(); 
builder.Services.AddScoped<IEditUserService , EditUserService>();   
builder.Services.AddScoped<IUserLoginService, UserLoginService>();  
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataBaseContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();
