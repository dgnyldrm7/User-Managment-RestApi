using Microsoft.EntityFrameworkCore;
using User_Managment_RestApi.ConnextContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Add database connection with SQLite

//Connnection string yazalým!
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    var config = builder.Configuration;
    var ConnectionString = config.GetConnectionString("DataBase");
    options.UseSqlite(ConnectionString);
});

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
