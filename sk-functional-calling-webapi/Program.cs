using sk_functional_calling_webapi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddHttpClient("ollamaClient", c => {
    c.BaseAddress = new Uri("http://localhost:11434");
    c.Timeout = TimeSpan.FromSeconds(30);
});

builder.Services.AddLogging();

builder.Services.AddSemanticKernel();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
