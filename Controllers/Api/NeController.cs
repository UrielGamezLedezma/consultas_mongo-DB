using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/Ne")]
public class NeController : Controller {
    [HttpGet("no-perez")]
    public IActionResult PropiedadesDeOtrasAgencias() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        // Filtro: Agencia != "Inmobiliaria Pérez"
        var filtroAgencia = Builders<Inmueble>.Filter.Ne(x => x.Agencia, "Inmobiliaria Pérez");

        var resultado = collection.Find(filtroAgencia).ToList();

        return Ok(resultado);
    }
}
