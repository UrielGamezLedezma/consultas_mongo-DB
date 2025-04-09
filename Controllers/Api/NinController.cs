using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/Nin")]
public class NinController : Controller {
    [HttpGet("filtrar")]
    public IActionResult PropiedadesFiltradas() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        // Filtros usando el operador Nin (Not In)
        var filtroTipo = Builders<Inmueble>.Filter.Nin(x => x.Tipo, new[] { "Casa", "Terreno" });
        var filtroOperacion = Builders<Inmueble>.Filter.Nin(x => x.Operacion, new[] { "Venta", "Renta" });
        var filtroPisos = Builders<Inmueble>.Filter.Nin(x => x.Pisos, new[] { 0, 1 });

        // Combinación de filtros
        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtroTipo, filtroOperacion, filtroPisos);

        var resultado = collection.Find(filtroCompuesto).ToList();

        return Ok(resultado);
    }
}
