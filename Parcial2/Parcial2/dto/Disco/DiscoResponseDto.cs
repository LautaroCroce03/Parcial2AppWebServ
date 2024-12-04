using DiscograficaWebApi.dto.Cancion;

namespace DiscograficaWebApi.dto.Disco;

public class DiscoResponseDto
{
    public string Titulo { get; set; }
    public string GeneroMusical { get; set; }
    public DateTime FechaLanzamiento { get; set; }
    public int CantidadVendida { get; set; }
    public string SKU { get; set; }
    public string? Banda { get; set; }
    public List<CancionResponseDto> Canciones { get; set; }
}
