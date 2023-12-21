using ApiNetJoke.Business.Interfaces;
using ApiNetJoke.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiNetJoke.Business
{
    public class NumberOperationService : INumberOperationService
    {
        public OrderNumberResult SortNumber(OrderNumberRequest orderNumberRequest)
        {
            IEnumerable<int> numbers = ParseNumbers(orderNumberRequest.Numbers);
            IEnumerable<int> orderedNumbers = new List<int>();

            if (orderNumberRequest.SortDirection == 0)
            {
                orderedNumbers = numbers.OrderBy(number => number);
            }
            else if (orderNumberRequest.SortDirection == 1)
            {
                orderedNumbers = numbers.OrderByDescending(number => number);
            }
            else
            {
                throw new ArgumentException($"Invalid order value. Expected 0 or 1. Actual {orderNumberRequest.SortDirection}");
            }

            OrderNumberResult result = new OrderNumberResult()
            {
                Numbers = string.Join(',', orderedNumbers),
                Sum = orderedNumbers.Sum(number => number)
            };

            return result;

        }

        private IEnumerable<int> ParseNumbers(string numbers)
        {
            // TODO : Support exceptions
            IEnumerable<int> parserNumbers = numbers.Split(",").Select(number => int.Parse(number));

            return parserNumbers;
        }
    }
}
