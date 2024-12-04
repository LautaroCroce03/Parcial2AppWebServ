using DiscograficaWebApi.dto.Cancion;

namespace DiscograficaWebApi.Services.Interface;

public interface ICancionService
{
    Task<CancionResponseDto> Create(CancionCreateRequestDto request);
    Task<List<CancionFilterResponseDto>> GetByFilter(CancionFilterRequestDto request);
}
