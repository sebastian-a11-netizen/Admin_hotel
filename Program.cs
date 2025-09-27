using Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Obtener el connection string desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Registrar el servicio Habitaciones
builder.Services.AddScoped(_ => new Habitaciones("Data Source=data/admin_hotel.db"));

builder.Services.AddControllers();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

app.Run();
