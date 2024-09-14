using IncidentManager.Api.Extensions;
using IncidentManager.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.AddPresentationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    await app.MigrateAsync();
}
app.UseGlobalExceptionHandler();

app.UseHttpsRedirection();
app.UseCors("all");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();