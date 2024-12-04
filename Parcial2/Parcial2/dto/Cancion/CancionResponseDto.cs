namespace DiscograficaWebApi.dto.Cancion;

public class CancionResponseDto
{
    public string Nombre { get; set; }
    public string GeneroMusical { get; set; }
    public int Duracion { get; set; }
    public DateTime FechaLanzamiento { get; set; }
    public string? Disco { get; set; }
}
