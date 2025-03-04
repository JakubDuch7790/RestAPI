using GodlessAPI;
using GodlessAPI.Data;
using GodlessAPI.Repository;
using GodlessAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options
        .UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnetion"))
        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
        .EnableSensitiveDataLogging();
});

builder.Services.AddScoped<IGodRepository, GodRepository>();
builder.Services.AddScoped<IGodNumberRepository, GodNumberRepository>();

builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services

    .AddControllers(/*option => option.ReturnHttpNotAcceptable=true*/)
    .AddNewtonsoftJson()
    .AddXmlDataContractSerializerFormatters();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
