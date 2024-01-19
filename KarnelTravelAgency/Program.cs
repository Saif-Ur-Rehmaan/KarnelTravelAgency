using KarnelTravelAgency.Core;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(
    builder.Configuration.GetConnectionString("KarnelTravelAgency_Saif")
    ));


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

app.UseAuthorization();

//------------------ RoutingConfiguration For Areas-------------//

//Default Route Configuration
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Areas Route Configuration
app.UseEndpoints(endpoints =>
{
    // Register area routes first, each with their desired area name
    _=endpoints.MapAreaControllerRoute(
            name: "PersonArea",
            areaName: "Person",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    _ = endpoints.MapAreaControllerRoute(
            name: "TransportArea",
            areaName: "Travel",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    _ = endpoints.MapAreaControllerRoute(
            name: "RestaurantArea",
            areaName: "Blog",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    _ = endpoints.MapAreaControllerRoute(
            name: "ResidenceArea",
            areaName: "Admin",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    _ = endpoints.MapAreaControllerRoute(
            name: "AdminArea",
            areaName: "Admin",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

  
});
//------------------ RoutingConfiguration For Areas-------------//


app.Run();
