using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/Eq")]
public class EqController : Controller {
    [HttpGet("costo")]
    public IActionResult PropiedadesConCostoExacto() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        // Filtro: Costo == 1331777
        var filtroCosto = Builders<Inmueble>.Filter.Eq(x => x.Costo, 1331777);

        var resultado = collection.Find(filtroCosto).ToList();

        return Ok(resultado);
    }
}
