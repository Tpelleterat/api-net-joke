using ApiNetJoke.Infrastructure.Interfaces;
using ApiNetJoke.Infrastructure.Models;
using ApiNetJoke.Infrastructure.RefitApiInterfaces;

namespace ApiNetJoke.Infrastructure
{
    public class JokeRequestService : IJokeRequestService
    {
        private readonly IOfficialJokeApi _officialJokeApi;

        public JokeRequestService(IOfficialJokeApi officialJokeApi)
        {
            _officialJokeApi = officialJokeApi;
        }

        public Task<OfficialJokeApiJokeResponse> GetJoke()
        {
            return _officialJokeApi.RandomJoke();
        }

        public Task<IEnumerable<OfficialJokeApiJokeResponse>> GetTenJokes()
        {
            return _officialJokeApi.RandomTenJokes();
        }
    }
}
