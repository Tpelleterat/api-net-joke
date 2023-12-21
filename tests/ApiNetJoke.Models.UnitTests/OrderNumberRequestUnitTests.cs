

using ApiNetJoke.Models.UnitTests.Helpers;
using System.ComponentModel.DataAnnotations;

namespace ApiNetJoke.Models.UnitTests
{
    public class OrderNumberRequestUnitTests
    {
        [Theory]
        [InlineData("5,2,10,3", 0, true)]
        [InlineData("5,2,10,3", 1, true)]
        [InlineData("5,2,10,3", -5, false)]
        [InlineData("5,2,10,3", 20, false)]
        [InlineData("5,2,10,", 0, false)]
        [InlineData("5,,10,4", 0, false)]
        public void ModelValidation(string number, int sortDirection, bool isValid)
        {
            var orderNumberRequest = new OrderNumberRequest()
            {
                Numbers = number,
                SortDirection = sortDirection
            };

            if (isValid)
            {
                Assert.Empty(ModelValidationHelper.ValidateModel(orderNumberRequest));
            }
            else
            {
                Assert.NotEmpty(ModelValidationHelper.ValidateModel(orderNumberRequest));
            }
        }


    }
}