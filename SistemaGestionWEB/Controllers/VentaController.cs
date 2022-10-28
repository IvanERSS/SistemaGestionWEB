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
        [HttpGet("all")]
        public List<Venta> Get()
        {
            return VentaRepository.Get();
        }

        [HttpGet("GetByUserId")]
        public List<Venta> GetByUserId(int _UserId)
        {

            return null;
        }

        [HttpPost("create")]
        public void Crear([FromBody] Dictionary<int,int> productoCantidad, string coments, int _IdUser)
        {
            VentaRepository.Create(productoCantidad, coments, _IdUser);
        }


    }
}
