using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/Nin")]
public class NinController : Controller {
    [HttpGet("no-venta-ni-renta")]
    public IActionResult PropiedadesQueNoSonVentaNiRenta() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        // Filtro: Operacion no es ni "Venta" ni "Renta"
        var filtroOperacion = Builders<Inmueble>.Filter.Nin(x => x.Operacion, new[] { "Venta", "Renta" });

        var resultado = collection.Find(filtroOperacion).ToList();

        return Ok(resultado);
    }
}