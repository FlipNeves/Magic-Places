using MagicPlaces_API.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicPlaces_API.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Places> Places { get; set; }
        public DbSet<PlacesNumber> PlacesNumbers { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Places>().HasData(
                new Places()
                {
                    Id = 1,
                    Name = "Tavernna",
                    Details = "Um restaurante tematizado ao estilo medieval.",
                    CreatedDate = DateTime.Now,
                    LastDate = DateTime.Now,
                    Comment = "Você paga pelo local, lindo. Não pela comida.",
                    Location = "St. Bueno. T2",
                    Rate = 8.4
                },
                new Places()
                {
                    Id = 2,
                    Name = "OFFICINA",
                    Details = "Um bom local para uma bebida.",
                    CreatedDate= DateTime.Now,
                    LastDate= DateTime.Now,
                    Comment = "A comida está mais do que aprovada.",
                    Location = "St. Bela Vista",
                    Rate = 8.5
                },
                new Places()
                {
                    Id = 3,
                    Name = "LIFE BOX",
                    Details = "Um restaurante/sanduicheria muito gostosa.",
                    CreatedDate = DateTime.Now,
                    LastDate = DateTime.Now,
                    Comment = "A comida e atendimento são exemplares. Ótimo local.",
                    Location = "Próximo ao Flamboyant Shopping",
                    Rate = 9.2
                });
        }
    }
}
