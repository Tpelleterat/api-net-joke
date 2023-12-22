using ApiNetJoke.Business.Interfaces;
using ApiNetJoke.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApiNetJoke.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class JokeController : ControllerBase
    {
        private readonly IJokeService _jokeService;

        public JokeController(IJokeService jokeService
            )
        {
            _jokeService = jokeService;
        }

        [HttpGet("")]
        public Task<IEnumerable<string>> SortNumbers([FromQuery][Range(1, 10)] int count = 1)
        {
            return _jokeService.GetJokes(count);
        }
    }
}
