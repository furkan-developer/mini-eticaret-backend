using OnionArch.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// add custom services declare
builder.Services.ConfigureMsSqlServer();
builder.Services.ConfigurePersistenceServices();
builder.Services.AddCors(corsOptions =>
{
    corsOptions.AddPolicy("Angular", configurePolicy =>
    {
         configurePolicy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Angular");

app.UseAuthorization();

app.MapControllers();

app.Run();
