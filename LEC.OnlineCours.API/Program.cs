#region Services Configuration
using LEC.OnlineCours.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;

// Db COnfiguration goes here
builder.Services.AddDbContext<OnlinecourseContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("StrConnectionDbContext"),
    providersOptions => providersOptions.EnableRetryOnFailure());
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region Midelwares Configuration
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
#endregion