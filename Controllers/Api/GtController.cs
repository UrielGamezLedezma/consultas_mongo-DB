using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/Gt")]
public class GtController : Controller {
    [HttpGet("mayor-a-200")]
    public IActionResult PropiedadesConConstruccionMayorA200() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        // Filtro: MetrosConstruccion > 200
        var filtroConstruccion = Builders<Inmueble>.Filter.Gt(x => x.MetrosConstruccion, 200);

        var resultado = collection.Find(filtroConstruccion).ToList();

        return Ok(resultado);
    }
}
