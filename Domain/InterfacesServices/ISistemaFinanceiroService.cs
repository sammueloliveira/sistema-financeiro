using Domain.Entities;

namespace Domain.InterfacesServices
{
    public interface ISistemaFinanceiroService
    {
        Task AddSistemaFinanceiro(SistemaFinanceiro sistema);
        Task UpdateSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro);
    }
}
