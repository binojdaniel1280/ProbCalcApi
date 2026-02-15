using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy
            //.WithOrigins("http://localhost:5173", "http://localhost:3000")
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


builder.Services.AddScoped<IProbabilityOperation, CombinedWithOperation>();
builder.Services.AddScoped<IProbabilityOperation, EitherOperation>();

builder.Services.AddScoped<IOperationProvider, OperationProvider>();
builder.Services.AddScoped<ILogService, FileLogService>();

builder.Services.AddScoped<ProbabilityEngine>();

var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseCors("AllowReactApp");

app.MapControllers();

app.Run();
