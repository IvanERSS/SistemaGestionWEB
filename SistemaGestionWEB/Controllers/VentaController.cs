using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionWEB.Models;
using SistemaGestionWEB.Repository;

namespace SistemaGestionWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpGet]
        public List<Venta> Get()
        {
            return VentaRepository.Get();
        }

        [HttpPost()]
        public void Crear([FromBody] Dictionary<Producto,int> productoCantidad, string coments)
        {
            VentaRepository.Crear(productoCantidad, coments);
        }
    }
}
