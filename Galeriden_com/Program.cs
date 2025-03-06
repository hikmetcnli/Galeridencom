var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();

app.MapControllerRoute(name: "default",
            pattern: "{controller=Home}/{action=Index}"
            );

app.Run();
