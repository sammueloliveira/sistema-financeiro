using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfacesServices;

namespace Domain.Services
{
    public class ServiceCategoria : IServiceCategoria
    {
        private readonly ICategoria _ICategoria;
        public ServiceCategoria(ICategoria categoria)
        {
            _ICategoria = categoria;
        }
        public async Task AddCategoria(Categoria categoria)
        {
            await _ICategoria.Add(categoria);
        }

        public async Task UpdateCategoria(Categoria categoria)
        {
            await _ICategoria.Update(categoria);
        }
    }
}
