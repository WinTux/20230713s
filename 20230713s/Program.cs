using _20230713s.Contenido;
using _20230713s.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>( op => op.UseSqlite(builder.Configuration.GetConnectionString("MiConexionLocalSQLite")));
var app = builder.Build();
app.MapGet("api/plato", async (AppDbContext contexto) => {
    var elementos = await contexto.Platos.ToListAsync();
    return Results.Ok(elementos);
});
app.MapPost("api/plato", async (AppDbContext contexto, Plato plato) => {
    var elementos = await contexto.Platos.AddAsync(plato);
    await contexto.SaveChangesAsync();
    return Results.Created($"api/plato/{plato.id}", plato);//HTTP 201, URI y objeto
});
app.MapPut("api/plato/{cod}", async (AppDbContext contexto, int cod, Plato plato) => {
    var platoModelo = await contexto.Platos.FirstOrDefaultAsync(p => p.id == cod);
    if (platoModelo == null)
        return Results.NotFound();// Error 404
    platoModelo.nombre = plato.nombre;
    await contexto.SaveChangesAsync();
    return Results.NoContent(); // HTTP 204
});
app.MapDelete("api/plato/{cod}", async (AppDbContext contexto, int cod) => {
    var platoModelo = await contexto.Platos.FirstOrDefaultAsync(p => p.id == cod);
    if (platoModelo == null)
        return Results.NotFound();// Error 404
    contexto.Platos.Remove(platoModelo);
    await contexto.SaveChangesAsync();
    return Results.NoContent(); // HTTP 204
});
app.Run();
