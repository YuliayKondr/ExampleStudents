using ExampleMinimalApi;
using ExampleMinimalApi.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

builder.Services.AddAutoMapper(typeof(IClientAssemblyMarker).Assembly);
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(IClientAssemblyMarker).Assembly));

builder.DatabaseDI();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health");

app.Run();