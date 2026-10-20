using SGRH.IOC;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSgrhServices(builder.Configuration.GetConnectionString("SgrhDb")!);

var app = builder.Build();

app.MapGet("/", () => Results.Content("<h1>SGRH - Sistema de Gestion de Reservas de Hoteles</h1>", "text/html"));

app.Run();
