using Domain.Entities;

namespace Domain.InterfacesServices
{
    public interface IServiceDespesa
    {
        Task AddDespesa(Despesa despesa);
        Task UpdateDespesa(Despesa despesa);
    }
}
