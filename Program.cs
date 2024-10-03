using apiPrueba1.src.Data;
using apiPrueba1.src.Interfaces;
using apiPrueba1.src.Repository;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string connectionString = Environment.GetEnvironmentVariable("DATABASE_URL") ?? "Data Source";
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlite(connectionString));
builder.Services.AddControllers();

builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();

    using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDBContext>();
    await context.Database.MigrateAsync();
    await Seeder.Seed(context);
}

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();
