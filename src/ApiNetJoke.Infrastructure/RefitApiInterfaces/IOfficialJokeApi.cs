using ApiNetJoke.Infrastructure.Models;
using Refit;

namespace ApiNetJoke.Infrastructure.RefitApiInterfaces
{
    public interface IOfficialJokeApi
    {

        [Get("/random_joke")]
        Task<OfficialJokeApiJokeResponse> RandomJoke();


        [Get("/random_ten")]
        Task<IEnumerable<OfficialJokeApiJokeResponse>> RandomTenJokes();
        
    }
}
