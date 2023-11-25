using Domain.Entities;

namespace Domain.InterfacesServices
{
    public interface IDespesaService
    {
        Task AddDespesa(Despesa despesa);
        Task UpdateDespesa(Despesa despesa);
    }
}
