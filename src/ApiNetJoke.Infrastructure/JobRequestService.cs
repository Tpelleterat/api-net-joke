using ApiNetJoke.Infrastructure.Interfaces;
using ApiNetJoke.Infrastructure.Models;
using ApiNetJoke.Infrastructure.RefitApiInterfaces;

namespace ApiNetJoke.Infrastructure
{
    public class JobRequestService : IJobRequestService
    {
        private readonly IOfficialJokeApi _officialJokeApi;

        public JobRequestService(IOfficialJokeApi officialJokeApi)
        {
            _officialJokeApi = officialJokeApi;
        }

        public Task<OfficialJokeApiJokeResponse> GetJobs()
        {
            return _officialJokeApi.RandomJoke();
        }
    }
}
