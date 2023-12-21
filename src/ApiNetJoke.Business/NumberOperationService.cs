using ApiNetJoke.Business.Interfaces;
using ApiNetJoke.Models;

namespace ApiNetJoke.Business
{
    public class NumberOperationService : INumberOperationService
    {
        public OrderNumberResult SortNumber(OrderNumberRequest orderNumberRequest)
        {
            IEnumerable<int> numbers = ParseNumbers(orderNumberRequest.Numbers);

            IEnumerable<int> orderedNumbers = SortedList(numbers, orderNumberRequest.SortDirection);

            OrderNumberResult result = CreateOrderNumberResult(orderedNumbers);

            return result;
        }

        private IEnumerable<int> SortedList(IEnumerable<int> numbers, int? orderDirection)
        {
            IEnumerable<int> orderedNumbers = new List<int>();

            if (orderDirection == 0)
            {
                orderedNumbers = numbers.OrderBy(number => number);
            }
            else if (orderDirection == 1)
            {
                orderedNumbers = numbers.OrderByDescending(number => number);
            }
            else
            {
                throw new ArgumentException($"Invalid order value. Expected 0 or 1. Actual {orderDirection}");
            }

            return orderedNumbers;
        }

        private OrderNumberResult CreateOrderNumberResult(IEnumerable<int> numbers)
        {
            return new OrderNumberResult()
            {
                Numbers = string.Join(',', numbers),
                Sum = numbers.Sum(number => number)
            };
        }

        private IEnumerable<int> ParseNumbers(string numbers)
        {
            IEnumerable<int> parserNumbers = numbers.Split(",").Select(number => int.Parse(number));

            return parserNumbers;
        }
    }
}
