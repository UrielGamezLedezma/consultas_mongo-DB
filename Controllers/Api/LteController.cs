using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/Lte")]
public class LteController : Controller {
    [HttpGet("cantidad-baños")]
    public IActionResult PropiedadesConMaximoDosBanos() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        // Filtro: NumeroBanos <= 2
        var filtroBanos = Builders<Inmueble>.Filter.Lte(x => x.Baños, 2);

        var resultado = collection.Find(filtroBanos).ToList();

        return Ok(resultado);
    }
}

