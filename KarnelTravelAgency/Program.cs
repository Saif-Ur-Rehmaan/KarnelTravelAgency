using KarnelTravelAgency.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("KarnelTravelAgency_Saif")
));

// Add session support
builder.Services.AddSession();

// Register HttpContextAccessor
builder.Services.AddHttpContextAccessor();


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

app.UseSession();

app.UseAuthorization();

//------------------ RoutingConfiguration For Areas-------------//



//Areas Route Configuration

app.MapControllerRoute(
           name: "default",
           pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    // Register area routes first, each with their desired area name
    _ = endpoints.MapAreaControllerRoute(
            name: "PersonArea",
            areaName: "Person",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    _ = endpoints.MapAreaControllerRoute(
            name: "TransportArea",
            areaName: "Transport",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    _ = endpoints.MapAreaControllerRoute(
            name: "RestaurantArea",
            areaName: "Restaurant",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    _ = endpoints.MapAreaControllerRoute(
            name: "ResidenceArea",
            areaName: "Residence",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    _ = endpoints.MapAreaControllerRoute(
            name: "AdminArea",
            areaName: "Admin",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
});

//------------------ RoutingConfiguration For Areas-------------//


app.Run();
