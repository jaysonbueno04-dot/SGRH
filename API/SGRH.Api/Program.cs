using SGRH.Domain.Repository;
using SGRH.IOC;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSgrhServices(builder.Configuration.GetConnectionString("SgrhDb")!);

var app = builder.Build();

app.MapGet("/api/hoteles", async (IHotelRepository repo) => Results.Ok(await repo.GetAllAsync()));
app.MapGet("/api/hoteles/{id:int}", async (int id, IHotelRepository repo) =>
    await repo.GetByIdAsync(id) is { } hotel ? Results.Ok(hotel) : Results.NotFound());

app.Run();
