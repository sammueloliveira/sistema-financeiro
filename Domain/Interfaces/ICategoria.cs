using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICategoria : IGeneric<Categoria>
    {
        Task<IList<Categoria>> ListarCategoriasUsuario(string emailUsuario);
    }
}
