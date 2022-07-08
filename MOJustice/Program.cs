using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MOE.Models;
using System.Text.Json.Serialization;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


//The AddJsonOptions to enable the DB object serialization to allow max length
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//to Enable componenets and there views
builder.Services.AddControllersWithViews()
    .AddRazorOptions(options =>
    {
        options.ViewLocationFormats.Add("/{0}.cshtml");
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<DataContext>(options =>
{
    //options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});

builder.Services.AddAuthentication(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Control/Users/Login";
    options.AccessDeniedPath = "/Control/Users/AccessDenied";

    options.Events = new CookieAuthenticationEvents()
    {
        //OnSigningIn = async context =>
        //{
        //    //Add Role Claim Identity before login is done
        //    var principal = context.Principal;
        //    if(principal.HasClaim(c => c.Type == ClaimTypes.NameIdentifier))
        //    {
        //        if(principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value == "fadi@intertech.ps")
        //        {
        //            var claimsIdentity = principal.Identity as ClaimsIdentity;
        //            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
        //        }
        //    }
        //    await Task.CompletedTask;
        //},
        //OnSignedIn = async conext =>
        //{
        //    await Task.CompletedTask;
        //},
        //OnValidatePrincipal = async context  =>
        //{
        //    await Task.CompletedTask;
        //}
    };
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins, builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();
//app.UsePathBase("/api");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors(myAllowSpecificOrigins);



app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseSession();   //To enable using of HttpContext.Session

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}"
      );
    endpoints.MapControllerRoute("default", "{lang=ar}/{controller=Home}/{action=Index}/{id?}/{Title?}");
    

    //endpoints.MapControllerRoute(
    //    name: "default",
    //    pattern: "{lang=ar}/{controller=Home}/{action=Index}"
    //);
});



app.MapRazorPages();

app.Run();
