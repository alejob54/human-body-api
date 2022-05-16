using Api.DTOs;
using Api.Exceptions;
using Api.Models;
using Api.Repositories;
using Api.Services;
using FluentAssertions;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class StomachServiceTests
    {
        private readonly Mock<IStomachRepository> _stomachRepository = new Mock<IStomachRepository>();
        private StomachService sut;

        public StomachServiceTests()
        {
            sut = new StomachService(_stomachRepository.Object);
        }

        #region Sample1
        //[Fact(DisplayName = "Eating a valid food")]
        //public async Task EastAsync_ValidFood_Succeess()
        //{
        //    _stomachRepository.Setup(m => m.StoreAsync(It.IsAny<NutrientDTO>(), It.IsAny<CancellationToken>()));

        //    Food food = new Food()
        //    {
        //        Calories = 23,
        //        FoodName = "Chicken"
        //    };

        //    await sut.EatAsync(food);

        //    _stomachRepository.Verify(m => m.StoreAsync(It.IsAny<NutrientDTO>(), It.IsAny<CancellationToken>()), Times.Once);
        //}
        #endregion

        #region Sample2
        [Theory(DisplayName = "Eating a valid foods")]
        [InlineData("Chicken", 32)]
        [InlineData("Brocoli", 2)]
        [InlineData("Milk", 40)]
        [InlineData("Fish", 3)]
        [InlineData("Salmon", 1)]
        [InlineData("Spinach", 7)]
        public async Task EastAsync_ValidFoods_Succeess(string foodName, int cal)
        {
            _stomachRepository.Setup(m => m.StoreAsync(It.IsAny<NutrientDTO>(), It.IsAny<CancellationToken>()));

            Food food = new Food()
            {
                Calories = cal,
                FoodName = foodName
            };

            await sut.EatAsync(food);

            _stomachRepository.Verify(m => m.StoreAsync(It.IsAny<NutrientDTO>(), It.IsAny<CancellationToken>()), Times.Once);
        }
        #endregion

        #region Sample3
        [Fact(DisplayName = "Eating an invalid food")]
        public async Task EastAsync_UnknownFoods__ThrowException()
        {
            _stomachRepository.Setup(m => m.StoreAsync(It.IsAny<NutrientDTO>(), It.IsAny<CancellationToken>()));

            Food food = new Food()
            {
                Calories = 23,
                FoodName = "Poison"
            };

            await sut.Invoking(d => d.EatAsync(food))
                .Should().ThrowAsync<UnknownFoodException>()
                .WithMessage("Oops! Unknown Food!");

            _stomachRepository.Verify(m => m.StoreAsync(It.IsAny<NutrientDTO>(), It.IsAny<CancellationToken>()), Times.Never);
        }
        #endregion
    }
}
