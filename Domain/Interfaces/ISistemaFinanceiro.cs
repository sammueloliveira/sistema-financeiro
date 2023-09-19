using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ISistemaFinanceiro : IGeneric<SistemaFinanceiro>
    {
        Task<IList<SistemaFinanceiro>> ListaSistemasUsuario(string emailUsuario);
    }
}
