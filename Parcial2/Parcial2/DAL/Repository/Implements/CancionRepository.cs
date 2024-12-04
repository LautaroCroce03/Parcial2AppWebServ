using DiscograficaWebApi.DAL.Data;
using DiscograficaWebApi.dto.Cancion;
using DiscograficaWebApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace DiscograficaWebApi.DAL.Repository.Implements;

public class CancionRepository : Repository<Cancion>, ICancionRepository
{
    public CancionRepository(DataContext context) : base(context)
    {
    }

    public async Task<Cancion> GetByNombre(string nombre)
    {
        var result = await _context.Canciones.FirstOrDefaultAsync(c => c.Nombre == nombre);

        return result;
    }

    public async Task<List<Cancion>> GetByFilter(CancionFilterRequestDto request)
    {
        var query = _context.Canciones.AsQueryable();

        if (!string.IsNullOrEmpty(request.Nombre))
        {
            query = query.Where(c => c.Nombre.Contains(request.Nombre));
        }

        if (request.Duracion.HasValue)
        {
            query = query.Where(c => c.Duracion == request.Duracion.Value);
        }

        if (!string.IsNullOrEmpty(request.GeneroMusical))
        {
            query = query.Where(c => c.GeneroMusical == request.GeneroMusical);
        }

        return await query.ToListAsync();
    }
}
