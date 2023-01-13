using BikeStationsMvc.Repository;
using BikeStationsMvc.Repository.Interfaces;
using BikeStationsMvc.Settings;
using BikeStationsMvc.Settings.Interfaces;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDataRepository, DataRepository>();
builder.Services.Configure<ConnectionSettings>(builder.Configuration.GetSection("ApiUrl"));
builder.Services.AddSingleton<IConnectionSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<ConnectionSettings>>().Value;
});
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

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
