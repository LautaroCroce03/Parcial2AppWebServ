using DiscograficaWebApi.dto.Cancion;
using DiscograficaWebApi.Entity;

namespace DiscograficaWebApi.DAL.Repository;

public interface ICancionRepository : IRepository<Cancion>
{
    Task<Cancion> GetByNombre(string nombre);
    Task<List<Cancion>> GetByFilter(CancionFilterRequestDto request);
}
