namespace DiscograficaWebApi.dto.Cancion;

public class CancionCreateRequestDto
{
    public string Nombre { get; set; }
    public string GeneroMusical { get; set; }
    public int Duracion { get; set; }
    public DateTime FechaLanzamiento { get; set; }
    public long? DiscoId { get; set; }
}
