using ApiProductos.Context;
using ApiProductos.Models;
using ApiProductos.Repository;
using ApiProductos.Repository.iRepository;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("CadenaSQL");

// Registra el contexto de la base de datos
builder.Services.AddDbContext<ProductosDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IRepository<Productos>, ProductosRepository>();
builder.Services.AddScoped<IRepository<Categoria>, CategoriaRepository>();
builder.Services.AddScoped<IRepository<Detalle_Venta>, DetalleVentaRepository>();
builder.Services.AddScoped<IRepository<Usuario>, UsuarioRepository>();
builder.Services.AddScoped<IRepository<Venta>, VentaRepository>();
builder.Services.AddScoped<IRepository<Cliente>, ClienteRepository>();

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
