using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfacesServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/usuario-sistema-financeiro")]
    [ApiController]
    [Authorize]
    public class UsuarioSistemaFinanceiroController : ControllerBase
    {
        private readonly IUsuarioSistemaFinanceiro _usuarioSistemaFinanceiro;
        private readonly IUsuarioSistemaFinanceiroService _usuarioSistemaFinanceiroService;
        public UsuarioSistemaFinanceiroController(IUsuarioSistemaFinanceiro InterfaceUsuarioSistemaFinanceiro,
            IUsuarioSistemaFinanceiroService IUsuarioSistemaFinanceiroServico)
        {
            _usuarioSistemaFinanceiro = InterfaceUsuarioSistemaFinanceiro;
            _usuarioSistemaFinanceiroService = IUsuarioSistemaFinanceiroServico;
        }

        [HttpGet("listar-usuarios-sistema")]
        [Produces("application/json")]
        public async Task<object> ListaSistemasUsuario(int idSistema)
        {
            return await _usuarioSistemaFinanceiro.ListarUsuariosSistema(idSistema);
        }


        [HttpPost("cadastrar-usuario-sistema")]
        [Produces("application/json")]
        public async Task<object> CadastrarUsuarioNoSistema(int idSistema, string emailUsuario)
        {
            try
            {
                await _usuarioSistemaFinanceiroService.CadastrarUsuarioNoSistema(
                   new UsuarioSistemaFinanceiro
                   {
                       IdSistema = idSistema,
                       EmailUsuario = emailUsuario,
                       Administrador = false,
                       SistemaAtual = true
                   });
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);

        }

        [HttpDelete("delete-usuario-sistema-financeiro")]
        [Produces("application/json")]
        public async Task<object> DeleteUsuarioSistemaFinanceiro(int id)
        {
            try
            {
                var usuarioSistemaFinanceiro = await _usuarioSistemaFinanceiro.GetEntityById(id);

                await _usuarioSistemaFinanceiro.Delete(usuarioSistemaFinanceiro);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);

        }
    }
}