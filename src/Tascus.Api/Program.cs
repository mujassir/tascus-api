using Tascus.Repo.Data;
using Tascus.Repo.GenericRepository.Interface;
using Tascus.Repo.GenericRepository.Service;
using Tascus.Service.Services;
using Microsoft.EntityFrameworkCore;
using Tascus.Core.Mappings;
using Tascus.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(OperationDataProfile), typeof(ProductionDataProfile));

builder.Services.AddDbContext<RepositoryContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IOperationDataRepository, OperationDataRepository>();
builder.Services.AddScoped<IProductionDataRepository, ProductionDataRepository>();
builder.Services.AddScoped<IProductionDataServices, ProductionDataServices>();
builder.Services.AddScoped<IOperationDataService, OperationDataService>();

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
