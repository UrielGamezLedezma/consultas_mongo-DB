using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/gte")]
public class GteController : Controller{
    [HttpGet("agente-baños-costo")]
    public IActionResult CantidadDeBaños(int Baños) {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

         var filtroAgentes = Builders<Inmueble>.Filter.In(x => x.NombreAgente, "agentes");
         var filtroBaños = Builders<Inmueble>.Filter.Gte(x => x.Baños, "baños");

         var filtroCompuesto = Builders<Inmueble>.Filter.And(filtroAgentes, filtroBaños);
         var list = collection.Find(filtroCompuesto).ToList();

         return Ok(list);
    }

}