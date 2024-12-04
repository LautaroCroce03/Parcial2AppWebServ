namespace DiscograficaWebApi.dto.Disco;

public class DiscoFilterResponseDto
{
    public string Titulo { get; set; }
    public string GeneroMusical { get; set; }
    public DateTime FechaLanzamiento { get; set; }
    public int CantidadVendida { get; set; }
    public int CantidadCanciones { get; set; }
    public string? Banda { get; set; }
}
