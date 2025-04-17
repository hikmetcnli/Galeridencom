using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
        AddCookie(
                x =>
                {
                    x.Cookie.Name = "NETCORE.Auth";
                    x.LoginPath = "/Login/Index";
                    x.AccessDeniedPath = "/AccesDenied/Index";
                }
                );

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(name: "default",
            pattern: "{controller=Login}/{action=Index}"
            );

app.Run();
