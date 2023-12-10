using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfacesServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sistema_Financeiro.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoria _categoria;
        private readonly ICategoriaService _categoriaService;
        public CategoriaController(ICategoria categoria, ICategoriaService categoriaService)
        {
            _categoria = categoria;
            _categoriaService = categoriaService;
        }

        [Authorize]
        [HttpGet("listar-categorias-usuario")]
        [Produces("application/json")]
        public async Task<Object> ListarCategoriasUsuario(string emailUsuario)
        {
            return await _categoria.ListarCategoriasUsuario(emailUsuario);
        }

        [Authorize]
        [HttpPost("adicionar-categoria")]
        [Produces("application/json")]
        public async Task<object> AdicionarCategoria(Categoria categoria)
        {
            await _categoriaService.AddCategoria(categoria);

            return categoria;
        }

        [Authorize]
        [HttpPut("atualizar-categoria")]
        [Produces("application/json")]
        public async Task<object> AtualizarCategoria(Categoria categoria)
        {
            await _categoriaService.UpdateCategoria(categoria);

            return categoria;
        }

        [Authorize]
        [HttpGet("obter-categoria")]
        [Produces("application/json")]
        public async Task<object> ObterCategoria(int id)
        {
            return await _categoria.GetEntityById(id);
        }

        [Authorize]
        [HttpDelete("delete-categoria")]
        [Produces("application/json")]
        public async Task<object> DeleteCategoria(int id)
        {
            try
            {
                var categoria = await _categoria.GetEntityById(id);
                await _categoria.Delete(categoria);

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }



    }
}

