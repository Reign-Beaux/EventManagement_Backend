using Application;
using Infraestructure;
using Web.API;
using Web.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddAPI(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfraestructure();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
      name: "cors",
      builder =>
      {
          builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseCors("cors");

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
