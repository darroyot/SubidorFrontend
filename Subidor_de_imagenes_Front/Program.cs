using Subidor_de_imagenes_Front.Interfaces;
using Subidor_de_imagenes_Front.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();



builder.Services.AddHttpClient();
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//          {
//              options.Cookie.HttpOnly = true;
//              options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
//              options.LoginPath = "Home/Login";
//              options.AccessDeniedPath = "/Home/AccessDenied";
//              options.SlidingExpiration = true;
//          }
//    );
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;

}
    );

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
//app.UseSession();

app.MapControllerRoute(
    name: "default",
   pattern: "{controller=Subidor}/{action=Main}/{id?}"
    );
app.Run();