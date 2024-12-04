using DiscograficaWebApi.dto.Cancion;
using DiscograficaWebApi.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiscograficaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancionesController : ControllerBase
    {
        private readonly ILogger<CancionesController> _logger;
        private readonly ICancionService _cancionService;

        public CancionesController(ILogger<CancionesController> logger, ICancionService cancionService)
        {
            _logger = logger;
            _cancionService = cancionService;
        }

        [HttpGet("GetByFilter")]
        public async Task<ActionResult<List<CancionFilterResponseDto>>> GetByFilter([FromQuery] CancionFilterRequestDto request)
        {
            try
            {
                var canciones = await _cancionService.GetByFilter(request);
                if (canciones.Count == 0)
                {
                    _logger.LogWarning("No se encontraron canciones");
                    return NotFound("No se encontraron canciones");
                }

                return Ok(canciones);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las canciones");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener las canciones");
            }
        }

        [Authorize]
        [HttpPost("CrearCancion")]
        public async Task<ActionResult<CancionResponseDto>> Create([FromBody] CancionCreateRequestDto request)
        {
            try
            {
                _logger.LogInformation("CreateCancion");

                var cancion = await _cancionService.Create(request);

                return Ok(cancion);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la canción");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear la canción");
            }
        }
    }
}
