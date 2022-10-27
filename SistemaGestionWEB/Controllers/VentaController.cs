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

        [HttpPost("Create")]
        public void Crear([FromBody] Dictionary<int,int> productoCantidad, string coments, int _IdUser)
        {
            VentaRepository.Create(productoCantidad, coments, _IdUser);
        }
    }
}
