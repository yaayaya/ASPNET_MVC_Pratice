using ASPNET_MVC.ActionFilters;
using ASPNET_MVC.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// filter套用全站
builder.Services.AddControllersWithViews(builder =>
{
    builder.Filters.Add<計算每個頁面的實際執行時間Attribute>();
});
 
builder.Services.AddDbContext<ContosoUniversityContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 註冊才能注入
builder.Services.AddScoped<計算每個頁面的實際執行時間Attribute>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();