using DiscograficaWebApi.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace WebApI_Preparcial_II.Dal.Data.DataSeed
{
    public class DiscoSeed : IEntityTypeConfiguration<Disco>
    {
        public void Configure(EntityTypeBuilder<Disco> builder)
        {

            builder.HasData(new Disco
            {
                Id = 1,
                Titulo = "The Dark Side of the Moon",
                GeneroMusical = "Rock",
                FechaLanzamiento = new System.DateTime(1973, 3, 1),
                CantidadVendida = 4500000,
                SKU = "DSM",
                Banda = "Pink Floyd"
            },
            new Disco
            {
                Id = 2,
                Titulo = "Thriller",
                GeneroMusical = "Pop",
                FechaLanzamiento = new System.DateTime(1982, 11, 30),
                CantidadVendida = 70000000,
                SKU = "THR",
                Banda = "Michael Jackson"
            },
            new Disco
            {
                Id = 3,
                Titulo = "Back in Black",
                GeneroMusical = "Rock",
                FechaLanzamiento = new System.DateTime(1980, 7, 25),
                CantidadVendida = 50000000,
                SKU = "BIA",
                Banda = "AC/DC"
            });
        }
    }
}
