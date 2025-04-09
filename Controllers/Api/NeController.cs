using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/Ne")]
public class NeController : Controller {
    [HttpGet("excluir-casa-venta")]
    public IActionResult PropiedadesFiltradas() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        // Filtros:
        var filtroTipo = Builders<Inmueble>.Filter.Ne(x => x.Tipo, "Casa");
        var filtroOperacion = Builders<Inmueble>.Filter.Ne(x => x.Operacion, "Venta");
        var filtroPisos = Builders<Inmueble>.Filter.Gt(x => x.Pisos, 1);

        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtroTipo, filtroOperacion, filtroPisos);

        var resultado = collection.Find(filtroCompuesto).ToList();

        return Ok(resultado);
    }
}
