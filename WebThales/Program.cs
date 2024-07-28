using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebThales.Services;
using Microsoft.AspNetCore.Identity;

using Business.Logic;
using Microsoft.Extensions.Options;
using System.Net.Http;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var urlEmployees = builder.Configuration["ApiSettings:UrlEmployees"];
var urlEmployeeId = builder.Configuration["ApiSettings:UrlEmployeeId"];

List<string> methods = new List<string>() { urlEmployees, urlEmployeeId };
builder.Services.AddSingleton(methods);



builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Duración de la sesión
    options.Cookie.HttpOnly = true; // La cookie de sesión solo se puede acceder desde el servidor
    options.Cookie.IsEssential = true; // Marca la cookie de sesión como esencial
});


builder.Services.AddHttpClient<EmployeeLogic>(client =>
{
    client.BaseAddress = new Uri(urlEmployees);
    new EmployeeLogic(client, methods);
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession(); // ---

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    pattern: "{controller=Employees}/{action=Index}/{id?}");

app.Run();
