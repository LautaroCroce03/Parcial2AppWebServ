using AutoMapper;
using DiscograficaWebApi.DAL;
using DiscograficaWebApi.dto.Cancion;
using DiscograficaWebApi.Entity;
using DiscograficaWebApi.Services.Interface;

namespace DiscograficaWebApi.Services;

public class CancionService : ICancionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CancionService> _logger;

    public CancionService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CancionService> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CancionResponseDto> Create(CancionCreateRequestDto request)
    {
        try
        {
            var cancion = _mapper.Map<Cancion>(request);
            await _unitOfWork.CancionRepository.Add(cancion);

            var result = await _unitOfWork.Save();
            if (result == 0)
            {
                _logger.LogError("Error al guardar la nueva canción");
                throw new Exception("No se pudo guardar la nueva cancion");
            }

            var cancionResponse = _mapper.Map<CancionResponseDto>(cancion);

            return cancionResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear canción");
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<CancionFilterResponseDto>> GetByFilter(CancionFilterRequestDto request)
    {
        try
        {
            var canciones = await _unitOfWork.CancionRepository.GetByFilter(request);
            if (canciones.Count == 0)
            {
                _logger.LogWarning("No se encontraron canciones con los criterios de búsqueda proporcionados");
                throw new Exception("No se encontraron canciones");
            }

            var cancionesResponse = _mapper.Map<List<CancionFilterResponseDto>>(canciones);

            return cancionesResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener las canciones por filtro");
            throw new Exception(ex.Message);
        }
    }
}
