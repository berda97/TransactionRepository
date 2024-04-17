using Microsoft.EntityFrameworkCore;
using Serilog;
using TransactionRepository.Data;
using TransactionRepository.Interface;
using TransactionRepository.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TransactionDatabaseContext>();
builder.Services.AddScoped<IHashService,HashService>();
builder.Services.AddScoped<ITransactionService,TransactionService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration).CreateLogger();
builder.Host.UseSerilog();

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<TransactionDatabaseContext>();
    await SeedData.InitializeAsync(context);
    await AccountSeedData.InitializeAsync(context);
   
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
