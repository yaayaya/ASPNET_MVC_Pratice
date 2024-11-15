using ASPNET_MVC.ActionFilters;
using ASPNET_MVC.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// filter�M�Υ���
builder.Services.AddControllersWithViews(builder =>
{
    builder.Filters.Add<�p��C�ӭ�������ڰ���ɶ�Attribute>();
});
 
builder.Services.AddDbContext<ContosoUniversityContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ���U�~��`�J
builder.Services.AddScoped<�p��C�ӭ�������ڰ���ɶ�Attribute>();

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