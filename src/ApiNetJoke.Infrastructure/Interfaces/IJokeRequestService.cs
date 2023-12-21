using ApiNetJoke.Infrastructure.Models;

namespace ApiNetJoke.Infrastructure.Interfaces
{
    public interface IJokeRequestService
    {
        Task<OfficialJokeApiJokeResponse> GetJoke();

        Task<IEnumerable<OfficialJokeApiJokeResponse>> GetTenJokes();
    }
}
