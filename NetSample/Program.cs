using Microsoft.EntityFrameworkCore;
using NetSample.Database;
using NetSample.SampleService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<NetSampleContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NetSampleContext") ?? throw new InvalidOperationException("Connection string 'NetSampleContext' not found.")));

// Add services to the container.
builder.Services.AddSampleServiceServices();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
