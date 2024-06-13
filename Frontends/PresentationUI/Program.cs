using Microsoft.AspNetCore.Authentication.Cookies;
using PresentationUI.Services.Abstract;
using PresentationUI.Services.Concrete;
using PresentationUI.Registration;
using PresentationUI.Hubs;
using PresentationUI.TableDependencies.Services;
using PresentationUI.TableDependencies.Concrete;
using PresentationUI.MiddlewareExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.LoginPath = "/Login/Index";
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.Cookie.Name = "monstaCookie";
    options.SlidingExpiration = true;
});

builder.Services.AddAccessTokenManagement();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IIdentityService, IdentityService>();

builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ICommentService, CommentService>();
builder.Services.AddSingleton<AppHub>();
builder.Services.AddSingleton<CommentTableDependency>();

builder.Services.AddSignalR();

builder.Services.ApplicationService(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapHub<AppHub>("/appHub");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseSqlTableDependency<CommentTableDependency>(builder.Configuration.GetConnectionString("DefaultConnection"));

app.Run();
