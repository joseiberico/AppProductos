using ApiProductos.Context;
using ApiProductos.Credentials;
using ApiProductos.Models;
using ApiProductos.Services;
using ApiProductos.Services.iServices;
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


builder.Services.AddScoped<IRepository<Productos>, ProductosServices>();
builder.Services.AddScoped<IRepository<Categoria>, CategoriaServices>();
builder.Services.AddScoped<IRepository<Detalle_Venta>, DetalleVentaServices>();
builder.Services.AddScoped<IUsuario<Usuario>, UsuarioServices>();
builder.Services.AddScoped<IRepository<Venta>, VentaServices>();
builder.Services.AddScoped<IRepository<Cliente>, ClienteServices>();
// Register the API Key authorization filter
//builder.Services.AddScoped<APIKeyAuthorizeAttribute>();

//builder.Services.AddControllers().AddJsonOptions(options =>
//    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
//);


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

//app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
