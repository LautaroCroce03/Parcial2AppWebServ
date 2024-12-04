namespace DiscograficaWebApi.dto.Cancion;

public class CancionFilterRequestDto
{
    public string? Nombre { get; set; }
    public int? Duracion { get; set; }
    public string? GeneroMusical { get; set; }
}
