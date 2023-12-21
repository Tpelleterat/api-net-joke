using ApiNetJoke.Models;

namespace ApiNetJoke.Business.Interfaces
{
    public interface IJokeService
    {
        Task<IEnumerable<string>> GetJokes(int number = 1);
    }
}
