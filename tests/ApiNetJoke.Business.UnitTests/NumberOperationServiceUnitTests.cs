using ApiNetJoke.Business.Interfaces;
using ApiNetJoke.Models;

namespace ApiNetJoke.Business.UnitTests
{
    public class NumberOperationServiceUnitTests
    {
        private readonly INumberOperationService numberOperationService;

        public NumberOperationServiceUnitTests()
        {
            numberOperationService = new NumberOperationService();
        }

        [Theory]
        [InlineData("5,2,10,3", 0, "2,3,5,10", 20)]
        [InlineData("5,1,10,3", 1, "10,5,3,1", 19)]

        public void SortNumberShouldOrderValues(string numbers, int sortDirection, string orderedNumbers, int sum)
        {
            // Arrange
            OrderNumberRequest orderNumberRequest = new OrderNumberRequest
            {
                Numbers = numbers,
                SortDirection = sortDirection,
            };

            // Act
            OrderNumberResult result = numberOperationService.SortNumber(orderNumberRequest);

            // Assert
            Assert.Equal(sum, result.Sum);
            Assert.Equal(orderedNumbers, result.Numbers);
        }

        [Fact]
        public void OrderNumberBadOrderDirectionShouldThrowArgumentException()
        {

            // Arrange
            OrderNumberRequest orderNumberRequest = new OrderNumberRequest
            {
                Numbers = "",
                SortDirection = 4,
            };

            // Act
            Assert.Throws<ArgumentException>(() => numberOperationService.SortNumber(orderNumberRequest));

            // Assert
        }
    }
}