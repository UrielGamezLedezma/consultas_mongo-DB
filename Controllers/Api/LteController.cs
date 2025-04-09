using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/Lte")]
public class LteController : Controller {
    [HttpGet("costo-metros")]
    public IActionResult PropiedadesPorCostoYMetros() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        // Filtros: Costo <= 33421 y MetrosConstruccion <= 322
        var filtroCosto = Builders<Inmueble>.Filter.Lte(x => x.Costo, 33421);
        var filtroMetros = Builders<Inmueble>.Filter.Lte(x => x.MetrosConstruccion, 322);

        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtroCosto, filtroMetros);

        var resultado = collection.Find(filtroCompuesto).ToList();

        return Ok(resultado);
    }
}
