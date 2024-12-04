namespace DiscograficaWebApi.Entity;

public class Disco
{
    public long Id { get; set; }
    public string Titulo { get; set; }
    public string GeneroMusical { get; set; }
    public DateTime FechaLanzamiento { get; set; }
    public int CantidadVendida { get; set; } = 0;
    public string SKU { get; set; }
    public string? Banda { get; set; }
    public List<Cancion> Canciones { get; set; }
}
