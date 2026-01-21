using Microsoft.EntityFrameworkCore;
using PersonasApi.Models;
using PersonasApi.Services;
var builder = WebApplication.CreateBuilder(args);



// Adding DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adding my own services
builder.Services.AddScoped<PersonasService>();
builder.Services.AddScoped<UsuarioService>();

// Add services to the container.
builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Serve static files from wwwroot
app.UseDefaultFiles();   // Looks for index.html by default
app.UseStaticFiles();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
