using ApiNetJoke.Business.Interfaces;
using ApiNetJoke.Infrastructure.Interfaces;
using ApiNetJoke.Infrastructure.Models;

namespace ApiNetJoke.Business
{
    public class JokeService : IJokeService
    {
        private readonly IJokeRequestService _jobRequestService;

        public JokeService(IJokeRequestService jobRequestService)
        {
            _jobRequestService = jobRequestService;
        }

        public Task<IEnumerable<string>> GetJokes(int number = 1)
        {
            if (number == 1)
            {
                return GetJokesOneByOne(number);
            }
            else
            {
                return GetJokesPerTen(number);
            }
        }

        private async Task<IEnumerable<string>> GetJokesOneByOne(int number = 1)
        {
            var jokes = new List<string>();

            for (int i = 0; i < number; i++)
            {
                OfficialJokeApiJokeResponse joke = await _jobRequestService.GetJoke();

                jokes.Add(joke.ToString());
            }

            return jokes;
        }

        private async Task<IEnumerable<string>> GetJokesPerTen(int number = 1)
        {
            IEnumerable<OfficialJokeApiJokeResponse> jokes = await _jobRequestService.GetTenJokes();

            return jokes.Take(number).Select(joke => joke.ToString());
        }
    }
}
