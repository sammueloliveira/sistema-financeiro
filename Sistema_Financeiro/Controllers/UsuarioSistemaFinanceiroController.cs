using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfacesServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioSistemaFinanceiroController : ControllerBase
    {
        private readonly IUsuarioSistemaFinanceiro _IUsuarioSistemaFinanceiro;
        private readonly IUsuarioSistemaFinanceiroService _IUsuarioSistemaFinanceiroService;
        public UsuarioSistemaFinanceiroController(IUsuarioSistemaFinanceiro InterfaceUsuarioSistemaFinanceiro,
            IUsuarioSistemaFinanceiroService IUsuarioSistemaFinanceiroServico)
        {
            _IUsuarioSistemaFinanceiro = InterfaceUsuarioSistemaFinanceiro;
            _IUsuarioSistemaFinanceiroService = IUsuarioSistemaFinanceiroServico;
        }

        [HttpGet("/api/ListarUsuariosSistema")]
        [Produces("application/json")]
        public async Task<object> ListaSistemasUsuario(int idSistema)
        {
            return await _IUsuarioSistemaFinanceiro.ListarUsuariosSistema(idSistema);
        }


        [HttpPost("/api/CadastrarUsuarioNoSistema")]
        [Produces("application/json")]
        public async Task<object> CadastrarUsuarioNoSistema(int idSistema, string emailUsuario)
        {
            try
            {
                await _IUsuarioSistemaFinanceiroService.CadastrarUsuarioNoSistema(
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

        [HttpDelete("/api/DeleteUsuarioSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> DeleteUsuarioSistemaFinanceiro(int id)
        {
            try
            {
                var usuarioSistemaFinanceiro = await _IUsuarioSistemaFinanceiro.GetEntityById(id);

                await _IUsuarioSistemaFinanceiro.Delete(usuarioSistemaFinanceiro);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);

        }
    }
}