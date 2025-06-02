using AG.Apis.Extensions;
using Swashbuckle.AspNetCore.SwaggerUI;

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
    c.DocumentTitle = "AG.Hotels API V1";
    c.InjectStylesheet("/swagger-ui/custom.css"); // Optional: Custom CSS for Swagger UI
    c.InjectJavascript("/swagger-ui/custom.js"); // Optional: Custom JS for Swagger UI
    c.DefaultModelsExpandDepth(-1); // Hide default models section
});

app.UseApisRoutes();

await app.RunAsync();