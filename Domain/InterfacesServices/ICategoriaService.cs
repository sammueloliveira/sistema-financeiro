using Domain.Entities;

namespace Domain.InterfacesServices
{
    public interface ICategoriaService
    {
        Task AddCategoria(Categoria categoria);
        Task UpdateCategoria(Categoria categoria);
    }
}
