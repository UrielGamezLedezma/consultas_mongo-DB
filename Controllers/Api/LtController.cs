using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/Lt")]
public class LtController : Controller {
    [HttpGet("menor-metros")]
    public IActionResult PropiedadesConConstruccionMenor() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        // Filtro: MetrosConstruccion < 578
        var filtroConstruccion = Builders<Inmueble>.Filter.Lt(x => x.MetrosConstruccion, 578);

        var resultado = collection.Find(filtroConstruccion).ToList();

        return Ok(resultado);
    }
}
