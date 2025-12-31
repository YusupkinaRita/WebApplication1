using WebApplication1;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddScoped<AccountBase>();
//builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<JWTService>();
builder.Services.AddControllers();
builder.Services.Configure<AuthSettings>(builder.Configuration.GetSection("AuthSettings"));
builder.Services.AddAuth(builder.Configuration);
builder.Services.AddData();


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//app.UseHttpsRedirection();


//app.MapGet("/", () => "Сервер работает, перейди на /task");
//app.MapGet("/test", () => "Тест работает");


//3 атаки: самые распространенные атаки на сервера и страницы, найти и попробовать и попробовать прогнать ее на себя 
