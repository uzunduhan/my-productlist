using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MyProductList;
using MyProductList.Data.DBOperations;
using MyProductList.Data.Models;
using MyProductList.Data.Repository.Abstract;
using MyProductList.Data.Repository.Concrete;
using MyProductList.Dto.Dtos;
using MyProductList.Extensions;
using MyProductList.Middlewares;
using MyProductList.Queues;
using MyProductList.Service.Abstract;
using PracticumHomeWork.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var conf = builder.Configuration;




builder.Services.Configure<ShopListMongoDatabaseSettings>(
    builder.Configuration.GetSection(nameof(ShopListMongoDatabaseSettings)));

builder.Services.AddSingleton<IShopListMongoDatabaseSettings>(sp =>
sp.GetRequiredService<IOptions<ShopListMongoDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
new MongoClient(builder.Configuration.GetValue<string>("ShopListMongoDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IShopListMongoService, ShopListMongoService>();


builder.Services.AddSingleton(typeof(IBackgroundTaskQueue<ShopList>), typeof(IsCompletedCheckQueue));

builder.Services.AddHostedService<QueueHostedService>();




builder.Logging.ClearProviders();
builder.Logging.AddDebug();
builder.Logging.AddConsole();

builder.Services.AddJwtConfig(conf);
builder.Services.AddServicesDI();
builder.Services.AddJwtBearerAuthentication();



builder.Services.AddControllers().AddNewtonsoftJson(options=>options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomizeSwagger();

builder.Services.AddCors(options => options.AddPolicy(name: "apiorigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));



//builder.Services.AddDbContext<DatabaseContext>(optins => optins.UseInMemoryDatabase(databaseName: "ParamDb"));

builder.Services.AddDbContext<DatabaseContext>(
       options => options.UseSqlServer("name=ConnectionStrings:SqlServerConnectionString"));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());








var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    //DataGenerator.Initialize(services);
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("apiorigins");

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<GlobalErrorHandlingMiddleware>();
app.UseRequestResponseMiddleware();


app.MapControllers();

app.Run();
