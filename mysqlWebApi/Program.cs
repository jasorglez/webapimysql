using Microsoft.EntityFrameworkCore;
using mysqlWebApi.Services;
using mysqlWebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _config = builder.Configuration;

var _cnx = _config.GetConnectionString("mysqlconexion");
                                       
//builder.Services.AddMySql<MagallanesContext>(_cnx, new MySqlServerVersion(new Version(8, 0, 27)));

var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

builder.Services.AddDbContext<MagallanesContext>(
            dbContextOptions => dbContextOptions
            .UseMySql(_cnx, serverVersion)

        // The following three options help with debugging, but should
        // be changed or removed for production.

        .LogTo(Console.WriteLine, LogLevel.Information)

        .EnableSensitiveDataLogging()

 .EnableDetailedErrors());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsuariosService, UsuariosService>();
builder.Services.AddScoped<IBancosService, BancosService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


