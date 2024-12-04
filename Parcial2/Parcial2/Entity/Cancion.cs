namespace DiscograficaWebApi.Entity;

public class Cancion
{
    public long Id { get; set; }
    public string Nombre { get; set; }
    public string GeneroMusical { get; set; }
    public int Duracion { get; set; }
    public DateTime FechaLanzamiento { get; set; }
    public long DiscoId { get; set; }
    public Disco Disco { get; set; }
}
