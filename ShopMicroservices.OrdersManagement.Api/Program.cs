using Microsoft.EntityFrameworkCore;
using Polly;
using ShopMicroservices.OrdersManagement.Api.Applications;
using ShopMicroservices.OrdersManagement.Api.DataAccess;
using ShopMicroservices.OrdersManagement.Api.ExternalServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ProductManagementService>();
builder.Services.AddScoped<ShopApplicationService>();
builder.Services.AddDbContext<OrdersManagementDBContext>(options =>
{
    options.UseInMemoryDatabase("OrdersManagementDb");
});

builder.Services.AddHttpClient<ProductManagementService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("Services:ProductManagementServiceBaseURI"));
})
.AddResilienceHandler("management-pipeline", builder =>
{
    builder.AddRetry(new Polly.Retry.RetryStrategyOptions<HttpResponseMessage>()
    {
        BackoffType = DelayBackoffType.Exponential,
        MaxRetryAttempts = 3,
        Delay = TimeSpan.FromSeconds(10)
    });
});

var app = builder.Build();

app.EnsureDbIsCreated();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();