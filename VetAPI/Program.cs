using Microsoft.EntityFrameworkCore;
using VetAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(
    options => {
        options.AddDefaultPolicy(
            policy => {
                policy.WithOrigins("http://example.com",
                                "http://www.contoso.com");
            }
        );
    }
);
builder.Services.AddDbContext<AppointmentContext>(opt =>
    opt.UseInMemoryDatabase("AppointmentList"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VetAPI v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
