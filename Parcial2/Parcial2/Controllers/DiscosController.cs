using DiscograficaWebApi.dto.Disco;
using DiscograficaWebApi.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiscograficaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscosController : ControllerBase
    {
        private readonly ILogger<DiscosController> _logger;
        private readonly IDiscoService _discoService;

        public DiscosController(ILogger<DiscosController> logger, IDiscoService discoService)
        {
            _logger = logger;
            _discoService = discoService;
        }

        [HttpGet("GetMasVendidos")]
        public async Task<ActionResult<DiscoResponseDto>> GetMasVendidos()
        {
            try
            {
                var disco = await _discoService.GetByMasVendidos();
                if (disco == null)
                {
                    _logger.LogWarning("No se encontraron discos");
                    return BadRequest("No se encontraron discos");
                }

                return Ok(disco);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los discos");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los discos");
            }
        }

        [HttpGet("GetByFilter")]
        public async Task<ActionResult<DiscoFilterResponseDto>> GetByFilter([FromQuery] DiscoFilterRequestDto request)
        {
            try
            {
                var disco = await _discoService.GetByFilter(request);
                if (disco == null)
                {
                    _logger.LogWarning("No se encontraron discos con los filtros seleccionados");
                    return BadRequest("No se encontraron discos con los filtros seleccionados");
                }

                return Ok(disco);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error, so se encontraron discos con los filtros seleccionados");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error, no se encontraron discos con los filtros seleccionados");
            }
        }

        [Authorize]
        [HttpPost("CrearDisco")]
        public async Task<ActionResult<DiscoResponseDto>> Create(DiscoCreateRequestDto request)
        {
            try
            {
                _logger.LogInformation("Crear disco");

                var disco = await _discoService.Create(request);
                if (disco == null)
                {
                    _logger.LogWarning("No se pudo crear el disco");
                    return BadRequest("No se pudo crear el disco");
                }

                return Ok(disco);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear disco");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear disco");
            }
        }

        [Authorize]
        [HttpPut("Update/{SKU}")]
        public async Task<ActionResult<DiscoResponseDto>> Update(string SKU, DiscoUpdateRequestDto request)
        {
            try
            {
                _logger.LogInformation("Actualizar");

                var disco = await _discoService.Update(SKU, request);
                if (disco == null)
                {
                    _logger.LogWarning("No se pudo actualizar el disco");
                    return BadRequest("No se pudo actualizar el disco");
                }

                return Ok(disco);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar disco");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar disco");
            }
        }
    }
}
