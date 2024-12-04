using DiscograficaWebApi.dto.Disco;
using DiscograficaWebApi.Entity;

namespace DiscograficaWebApi.DAL.Repository;

public interface IDiscoRepository : IRepository<Disco>
{
    Task<Disco> GetBySKU(string sku);
    Task<Disco> GetByTitulo(string titulo);
    Task<List<Disco>> GetTop5MasVendidos();
    Task<List<Disco>> GetByFilter(DiscoFilterRequestDto request);
}
