using DiscograficaWebApi.DAL.Data;
using DiscograficaWebApi.dto.Disco;
using DiscograficaWebApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace DiscograficaWebApi.DAL.Repository.Implements;

public class DiscoRepository : Repository<Disco>, IDiscoRepository
{
    public DiscoRepository(DataContext context) : base(context)
    {
    }

    public async Task<Disco> GetByTitulo(string titulo)
    {
        var result = await _context.Discos.FirstOrDefaultAsync(d => d.Titulo == titulo);

        return result;
    }

    public async Task<Disco> GetBySKU(string sku)
    {
        var result = await _context.Discos.FirstOrDefaultAsync(d => d.SKU == sku);

        return result;
    }

    public async Task<List<Disco>> GetTop5MasVendidos()
    {
        var result = await _context.Discos.OrderByDescending(d => d.CantidadVendida)
            .Take(5)
            .Include(d => d.Canciones)
            .ToListAsync();

        return result;
    }

    public async Task<List<Disco>> GetByFilter(DiscoFilterRequestDto request)
    {
        var query = _context.Discos.Include(d => d.Canciones).AsQueryable();

        if (!string.IsNullOrEmpty(request.GeneroMusical))
        {
            query = query.Where(d => d.GeneroMusical == request.GeneroMusical);
        }

        if (!string.IsNullOrEmpty(request.Titulo))
        {
            query = query.Where(d => d.Titulo.Contains(request.Titulo));
        }

        if (request.CantidadVendida.HasValue)
        {
            query = query.Where(d => d.CantidadVendida >= request.CantidadVendida.Value);
        }

        return await query.ToListAsync();
    }
}
