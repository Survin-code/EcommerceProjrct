using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Services;
using EncryptSolution;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProductService, ProductService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddAutoEncryption("MySecretKey123"); 

// register package interceptors
builder.Services.AddAutoEncryption(builder.Configuration["EncryptionSetting:Key"] ?? "MySuperSecretKey_ReplaceMe_32chars!");

// your DB context
builder.Services.AddDbContext<AppDbContext>((sp, options) =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConStr"));

    // Attach all IInterceptor implementations 
    var interceptors = sp.GetServices<IInterceptor>();
    foreach (var interceptor in interceptors)
        options.AddInterceptors(interceptor);
});

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDevClient", policy =>
    {
        policy.WithOrigins("http://localhost:4200").
           AllowAnyHeader()
           .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAngularDevClient");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
