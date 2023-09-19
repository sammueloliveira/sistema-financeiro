using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IDespesa : IGeneric<Despesa>
    {
        Task<IList<Despesa>> ListarDespesasUsuario(string emailUsuario);

        Task<IList<Despesa>> ListarDespesasUsuarioNaoPagasMesesAnterior(string emailUsuario);
    }
}
