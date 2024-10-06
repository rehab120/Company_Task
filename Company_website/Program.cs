using Company_website.Models.Context;
using Company_website.Reporsitry;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(
 OptionsBuilder =>
 {
    OptionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("con"));
 }

);
builder.Services.AddScoped<IEmployeeReporsitry,EmployeeReporsitry>();
builder.Services.AddScoped<IComoanyReporsitry,CompanyReporsitry>();
var app = builder.Build();

// Specify a custom URL and port
app.Urls.Add("http://localhost:5194"); // Change port if needed

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
