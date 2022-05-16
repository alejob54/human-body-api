using Api.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class HumanBodyContext : DbContext
    {
        public DbSet<NutrientDTO> Nutrients { get; set; }
        public DbSet<NutrientTypeDTO> NutrientTypes { get; set; }

        public HumanBodyContext(DbContextOptions<HumanBodyContext> options) : 
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NutrientTypeDTO>()
                .HasData(DTOs.NutrientTypes.Macronutrient, DTOs.NutrientTypes.Micronutrient);
        }
    }
}
