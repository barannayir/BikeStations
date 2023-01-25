using BikeStationsApi.Repository.Interfaces;
using BikeStationsApi.Repository;
using BikeStationsApi.Settings;
using BikeStationsApi.Settings.Interfaces;
using Microsoft.Extensions.Options;
using BikeStationsApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBikeRepository, BikeRepository>();
builder.Services.AddScoped<IStationRepository, StationRepository>();
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("FilePaths"));
builder.Services.AddCors();
builder.Services.AddSingleton<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("./v1/swagger.json", "My API V1"); //originally "./swagger/v1/swagger.json"
});
app.UseDeveloperExceptionPage();
app.UseAuthorization();
app.UseCors(options => options.WithOrigins("http://localhost:8100").AllowAnyMethod().AllowAnyHeader());
app.MapControllers();

app.Run();
