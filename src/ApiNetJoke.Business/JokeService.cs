using ApiNetJoke.Business.Interfaces;
using ApiNetJoke.Infrastructure.Interfaces;
using ApiNetJoke.Infrastructure.Models;

namespace ApiNetJoke.Business
{
    public class JokeService : IJokeService
    {
        private readonly IJobRequestService _jobRequestService;

        public JokeService(IJobRequestService jobRequestService)
        {
            _jobRequestService = jobRequestService;
        }

        public async Task<IEnumerable<string>> GetJokes(uint number = 1)
        {
            var jokes = new List<string>();

            OfficialJokeApiJokeResponse joke = await _jobRequestService.GetJobs();

            jokes.Add(joke.Punchline);

            return jokes;
        }
    }
}
