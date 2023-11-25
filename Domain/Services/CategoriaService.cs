using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfacesServices;

namespace Domain.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoria _categoria;
        public CategoriaService(ICategoria categoria)
        {
            _categoria = categoria;
        }
        public async Task AddCategoria(Categoria categoria)
        {
            await _categoria.Add(categoria);
        }

        public async Task UpdateCategoria(Categoria categoria)
        {
            await _categoria.Update(categoria);
        }
    }
}
