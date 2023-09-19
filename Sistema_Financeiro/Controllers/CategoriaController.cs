using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfacesServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sistema_Financeiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoria _ICategoria;
        private readonly IServiceCategoria _IServiceCategoria;
        public CategoriaController(ICategoria categoria, IServiceCategoria serviceCategoria)
        {
            _ICategoria = categoria;
            _IServiceCategoria = serviceCategoria;
        }

        [Authorize]
        [HttpGet("/api/ListarCategoriasUsuario")]
        [Produces("application/json")]
        public async Task<Object> ListarCategoriasUsuario(string emailUsuario)
        {
            return await _ICategoria.ListarCategoriasUsuario(emailUsuario);
        }

        [Authorize]
        [HttpPost("/api/AdicionarCategoria")]
        [Produces("application/json")]
        public async Task<object> AdicionarCategoria(Categoria categoria)
        {
            await _IServiceCategoria.AddCategoria(categoria);

            return categoria;
        }

        [Authorize]
        [HttpPut("/api/AtualizarCategoria")]
        [Produces("application/json")]
        public async Task<object> AtualizarCategoria(Categoria categoria)
        {
            await _IServiceCategoria.UpdateCategoria(categoria);

            return categoria;
        }

        [Authorize]
        [HttpGet("/api/ObterCategoria")]
        [Produces("application/json")]
        public async Task<object> ObterCategoria(int id)
        {
            return await _ICategoria.GetEntityById(id);
        }

        [Authorize]
        [HttpDelete("/api/DeleteCategoria")]
        [Produces("application/json")]
        public async Task<object> DeleteCategoria(int id)
        {
            try
            {
                var categoria = await _ICategoria.GetEntityById(id);
                await _ICategoria.Delete(categoria);

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }



    }
}

