using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TRC.Core.Modelo;
using TRC.Manager.Interfaces;

namespace TRC.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoManager _estadoManager;
        public EstadoController(IEstadoManager estadoManager)
        {
            _estadoManager = estadoManager;
        }
        // GET: api/Estado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estado>>> GetEstadosAsync()
        {
            try
            {
                return Ok(await _estadoManager.GetEstadosAsync());
            }
            catch (Exception ex)
            {
                Exception exception = new Exception("Erro Inesperado.", ex);
                throw;
            }
        }
    }
}
