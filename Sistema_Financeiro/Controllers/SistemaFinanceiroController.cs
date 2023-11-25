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
    public class SistemaFinanceirosController : ControllerBase
    {
        private readonly ISistemaFinanceiro _sistemaFinanceiro;
        private readonly ISistemaFinanceiroService _sistemaFinanceiroService;
        public SistemaFinanceirosController(ISistemaFinanceiro sistemaFinanceiro,
            ISistemaFinanceiroService sistemaFinanceiroServico)
        {
            _sistemaFinanceiro = sistemaFinanceiro;
            _sistemaFinanceiroService = sistemaFinanceiroServico;
        }

        [HttpGet("/api/ListaSistemasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListaSistemasUsuario(string emailUsuario)
        {
            return await _sistemaFinanceiro.ListaSistemasUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            await _sistemaFinanceiroService.AddSistemaFinanceiro(sistemaFinanceiro);

            return Task.FromResult(sistemaFinanceiro);
        }

        [HttpPut("/api/AtualizarSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            await _sistemaFinanceiroService.UpdateSistemaFinanceiro(sistemaFinanceiro);

            return Task.FromResult(sistemaFinanceiro);
        }


        [HttpGet("/api/ObterSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> ObterSistemaFinanceiro(int id)
        {
            return await _sistemaFinanceiro.GetEntityById(id);
        }


        [HttpDelete("/api/DeleteSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> DeleteSistemaFinanceiro(int id)
        {
            try
            {
                var sistemaFinanceiro = await _sistemaFinanceiro.GetEntityById(id);

                await _sistemaFinanceiro.Delete(sistemaFinanceiro);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


    }
}