using LEC.OnlineCours.Data;
using LEC.OnlineCours.Data.Repository;
using LEC.OnlineCours.Data.Repository.Interfaces;
using LEC.OnlineCours.Services;
using LEC.OnlineCours.Services.RepoService;
using Microsoft.EntityFrameworkCore;

#region Services Configuration
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;

// Db COnfiguration goes here
var connectionString = configuration.GetConnectionString("StrConnectionDbContext");
if (string.IsNullOrEmpty(connectionString))
    throw new InvalidOperationException("La stringa di connessione non è configurata.");

builder.Services.AddDbContext<OnlinecourseContext>(options =>
{
    options.UseSqlServer(connectionString, providersOptions => providersOptions.EnableRetryOnFailure());
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICourseCategoryRepository, CourseCategoryRepository>();
builder.Services.AddScoped<ICourseCategoryService, CourseCategoryService>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();

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