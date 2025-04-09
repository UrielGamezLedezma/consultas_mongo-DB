using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/gte")]
public class GteController : Controller {
    [HttpGet("casas-venta-metros-terreno")]
    public IActionResult CosasEnVentaConMasDexTerreno(int metrosConstruccion) {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        var filtroCasas = Builders<Inmueble>.Filter.Eq(x => x.Tipo, "Casa");
        var filtroVenta = Builders<Inmueble>.Filter.Eq(x => x.Operacion, "Venta");
        var filtroMetros = Builders<Inmueble>.Filter.Gte(x => x.MetrosConstruccion, metrosConstruccion);

        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtroCasas, filtroVenta, filtroMetros);
        var list = collection.Find(filtroCompuesto).ToList();

        return Ok(list);
        
    }
}