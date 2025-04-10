using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/Gte")]
public class GteController : Controller {
    [HttpGet("casa-o-terreno")]
    public IActionResult PropiedadesCasaOTerreno() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        // Filtro: Tipo es "Casa" o "Terreno"
        var filtroTipo = Builders<Inmueble>.Filter.In(x => x.Tipo, new[] { "Casa", "Terreno" });

        var resultado = collection.Find(filtroTipo).ToList();

        return Ok(resultado);
    }
}
