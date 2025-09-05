using MongoDB.Driver;
using TeamBicep.WebApi.Models;
using TeamBicep.WebApi.Repositories;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add MongoDB services
builder.Services.AddSingleton<IMongoClient>(_ => new MongoClient(
    builder.Configuration["Mongo:ConnectionString"]
));
builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(builder.Configuration["Mongo:Database"]);
});
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost(
    "api/todos",
    async (Todo todo, ITodoRepository repo) =>
    {
        await repo.AddAsync(todo);
        return Results.Created();
    }
);

app.MapGet("api/todos", async (ITodoRepository repo) =>
{
    var todo = await repo.GetAllAsync();
    return Results.Ok(todo);
});

app.UseHttpsRedirection();

app.Run();