using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using User_Managment_RestApi.Models.ConnectContext;
using User_Managment_RestApi.Models.DTO;
using User_Managment_RestApi.Models.MapperProfile;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using User_Managment_RestApi.Models.Repository.UserRepo;
using User_Managment_RestApi.Models.Repository.RoleRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Add database connection with SQLite

//Connnection string yazalim!
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    var config = builder.Configuration;
    var ConnectionString = config.GetConnectionString("DataBase");
    options.UseSqlite(ConnectionString);
});


//Service configuration! - Interface dependency!
builder.Services.AddTransient<IUserRepository , UserRepository>();
builder.Services.AddTransient<IRoleRepository, RoleRepository>();


//add automapper
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(UserMapper).Assembly);
builder.Services.AddAutoMapper(typeof(RoleMapper).Assembly);
//builder.Services.AddAutoMapper(typeof(Startup));




//builder.Services.AddControllers().AddJsonOptions(x =>
//                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation    
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "Version-1",
        Title = "User-Role Managment System",
        Description = "User-Role Relation Managment - dgnyldrm7",
    });
});

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
