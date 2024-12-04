using DiscograficaWebApi.DAL.Data;
using DiscograficaWebApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace DiscograficaWebApi.DAL.Repository.Implements;

public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(DataContext context) : base(context)
    {
    }

    public async Task<Usuario> GetByUserName(string username)
    {
        var result = await _context.Usuarios.FirstOrDefaultAsync(u => u.UserName == username);

        return result;
    }
}
