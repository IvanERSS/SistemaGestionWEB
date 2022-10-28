using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionWEB.Models;
using SistemaGestionWEB.Repository;
using System.Diagnostics.CodeAnalysis;

namespace SistemaGestionWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet("all")]
        public List<ProductoVendido> Get()
        {
            return ProductoVendidoRepository.Get();
        }

        [HttpPost("create")]
        public void Create([FromBody] int idProducto,int idUsuario,int idVenta)
        {
            ProductoVendidoRepository.Crear(idProducto,idUsuario,idVenta);
        }
    }
}
