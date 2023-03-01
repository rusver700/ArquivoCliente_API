using ArquivoCliente_API.Modelo;
using ArquivoCliente_API.Servico;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/////////////////////New////////////////////////////////////
builder.Services.Configure<ClienteDatabaseSettings>
    (builder.Configuration.GetSection("DatabaseMongoDB"));

builder.Services.AddSingleton<ClienteServico>();
/////////////////////NewConfg.MongoDB///////////////////////////////

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

app.MapControllers();

app.Run();

