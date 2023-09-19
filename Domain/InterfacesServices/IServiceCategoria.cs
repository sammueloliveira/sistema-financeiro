using Domain.Entities;

namespace Domain.InterfacesServices
{
    public interface IServiceCategoria
    {
        Task AddCategoria(Categoria categoria);
        Task UpdateCategoria(Categoria categoria);
    }
}
