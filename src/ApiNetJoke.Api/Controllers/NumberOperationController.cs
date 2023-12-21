using ApiNetJoke.Business.Interfaces;
using ApiNetJoke.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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

        [HttpPost("sort")]
        public OrderNumberResult SortNumbers([FromQuery][Required] OrderNumberRequest orderNumberRequest)
        {
            return _numberOperationService.SortNumber(orderNumberRequest);
        }
    }
}
