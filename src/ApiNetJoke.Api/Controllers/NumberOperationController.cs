using ApiNetJoke.Business.Interfaces;
using ApiNetJoke.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiNetJoke.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberOperationController : ControllerBase
    {
        private readonly INumberOperationService _numberOperationService;

        public NumberOperationController(INumberOperationService numberOperationService
            )
        {
            _numberOperationService = numberOperationService;
        }

        [HttpPut("sort")]
        public OrderNumberResult SortNumbers(OrderNumberRequest orderNumberRequest)
        {
            return _numberOperationService.SortNumber(orderNumberRequest);
        }
    }
}
