using FixMe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/connectorconfig", (CustomerConfiguration config) => config)
    .WithOpenApi();

app.UseHttpsRedirection();

namespace FixMe
{
    public class CustomerConfiguration
    {
        public string Id { get; set; }
        //TODO: add
        public string ApiKey { get; set; }
    }
}

