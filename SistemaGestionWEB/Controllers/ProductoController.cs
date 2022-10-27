﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionWEB.Models;
using SistemaGestionWEB.Repository;

namespace SistemaGestionWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet ("Get")]
        public List<Producto> Get()
        {
            return ProductoRepository.Get();
        }

        [HttpPut("Update")]
        public void Update([FromBody]Producto _Producto)
        {
            ProductoRepository.Update(_Producto);
        }

        [HttpPut("Delete")]
        public void Delete([FromBody] int _ProductId)
        {
            ProductoRepository.Delete(_ProductId);
        }

        [HttpPost("Create")]
        public void Create([FromBody] Producto _Producto)
        {
            ProductoRepository.Create(_Producto);
        }

    }
}