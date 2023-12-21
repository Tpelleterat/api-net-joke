using ApiNetJoke.Infrastructure.Models;

namespace ApiNetJoke.Infrastructure.Interfaces
{
    public interface IJobRequestService
    {
        Task<OfficialJokeApiJokeResponse> GetJobs();
    }
}
