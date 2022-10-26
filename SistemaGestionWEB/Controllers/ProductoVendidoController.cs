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
        [HttpGet]
        public List<ProductoVendido> Get()
        {
            return ProductoVendidoRepository.Get();
        }
    }
}
