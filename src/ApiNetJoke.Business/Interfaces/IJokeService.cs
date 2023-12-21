using ApiNetJoke.Models;

namespace ApiNetJoke.Business.Interfaces
{
    public interface IJokeService
    {
        Task<IEnumerable<string>> GetJokes(uint number = 1);
    }
}
