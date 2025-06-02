using AG.Apis.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add Minimal API services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddHttpContextAccessor();
builder.AddApis();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AG.Hotels API V1");
    c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
});

app.UseApisRoutes();

await app.RunAsync();