using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.DTOs
{
    public class NutrientDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public NutrientTypeDTO NutrientType { get; set; }
        public int Energy { get; set; }
        public int Fiber { get; set; }
    }

    public class NutrientTypeDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
    }

    public class NutrientTypes
    {
        public static NutrientTypeDTO Micronutrient = new NutrientTypeDTO
        {
            Id = 1,
            Name = "Micronutrient"
        };

        public static NutrientTypeDTO Macronutrient = new NutrientTypeDTO
        {
            Id = 2,
            Name = "Macronutrient"
        };
    }
}
