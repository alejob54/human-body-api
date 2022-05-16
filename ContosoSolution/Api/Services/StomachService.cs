using Api.DTOs;
using Api.Exceptions;
using Api.Models;
using Api.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Services
{
    public class StomachService : IStomachService
    {
        private readonly IStomachRepository _repository;
        private static readonly Random RandomGenerator = new Random();
        public StomachService(IStomachRepository repository)
        {
            _repository = repository;
        }

        public async Task EatAsync(Food food, CancellationToken cancellationToken = default)
        {
            NutrientDTO nutrient = new NutrientDTO();

            if (IsMacro(food.FoodName))
            {
                nutrient.Energy = RandomGenerator.Next(1, 500) * food.Calories;
                nutrient.Fiber = 0;
                nutrient.NutrientType = NutrientTypes.Macronutrient;
            } 
            else
            {
                nutrient.Energy = 0;
                nutrient.Fiber = RandomGenerator.Next(1000, 5000);
                nutrient.NutrientType = NutrientTypes.Micronutrient;
            }

            await _repository.StoreAsync(nutrient);
        }

        private bool IsMacro(string foodName)
        {
            switch (foodName)
            {
                case "Chicken":
                case "Fish":
                case "Milk":
                case "Salmon":
                    return true;

                case "Spinach":
                case "Brocoli":
                    return false;

                default:
                    throw new UnknownFoodException();
            }
        }
    }
}
