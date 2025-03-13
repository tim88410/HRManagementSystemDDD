using DBUtility;
using HRManagementSystemDDD;
using HRManagementSystemDDD.Application.Queries;
using HRManagementSystemDDD.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<IDataBaseUtility, DataBaseUtility>(provider =>
    new DataBaseUtility(connectionString));

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureLayer();

// µù¥U MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

//AutoMapper
builder.Services.AddAutoMapper(
    (serviceProvider, mapperConfiguration) => mapperConfiguration.AddProfiles(new AutoMapper.Profile[]
    {
        new QueriesProfile()
    }),
    AppDomain.CurrentDomain.GetAssemblies());

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
