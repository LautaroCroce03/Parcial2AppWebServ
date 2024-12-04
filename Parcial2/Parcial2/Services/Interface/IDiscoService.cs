using DiscograficaWebApi.dto.Disco;

namespace DiscograficaWebApi.Services.Interface;

public interface IDiscoService
{
    Task<DiscoResponseDto> Create(DiscoCreateRequestDto request);
    Task<List<DiscoFilterResponseDto>> GetByMasVendidos();
    Task<List<DiscoFilterResponseDto>> GetByFilter(DiscoFilterRequestDto request);
    Task<DiscoResponseDto> Update(string SKU, DiscoUpdateRequestDto request);
}
