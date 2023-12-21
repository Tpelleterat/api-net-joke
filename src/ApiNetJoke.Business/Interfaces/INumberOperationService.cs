using ApiNetJoke.Models;

namespace ApiNetJoke.Business.Interfaces
{
    public interface INumberOperationService
    {
        OrderNumberResult SortNumber(OrderNumberRequest orderNumberRequest);
    }
}
