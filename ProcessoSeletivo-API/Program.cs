using Microsoft.EntityFrameworkCore;
using ProcessoSeletivo_API.Persistence.Context;
using ProcessoSeletivo_API.Repository;
using ProcessoSeletivo_API.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConnectionString = builder.Configuration.GetConnectionString("ProcessoConnection");
builder.Services.AddDbContext<ContextAPI>(o => o.UseSqlServer(ConnectionString));

builder.Services.AddSingleton(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(CandidatoProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IServiceCandidato, ServiceCandidato>();
builder.Services.AddScoped<IRepositoryCandidato, RepositoryCandidato>();
builder.Services.AddScoped<IServiceEmail, ServiceEmail>();

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
