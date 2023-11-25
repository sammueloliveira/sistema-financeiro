using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfacesServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sistema_Financeiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DespesaController : ControllerBase
    {
        private readonly IDespesa _IDespesa;
        private readonly IDespesaService _IDespesaService;

        public DespesaController(IDespesa iDespesa, IDespesaService iDespesaService)
        {
            _IDespesa = iDespesa;
            _IDespesaService = iDespesaService;
        }

        [HttpGet("/api/ListarDespesasUsuario")]
        [Produces("application/json")]
        public async Task<IActionResult> ListarDespesasUsuario([FromQuery] string emailUsuario)
        {
            var despesas = await _IDespesa.ListarDespesasUsuario(emailUsuario);
            return Ok(despesas);
        }


        [HttpPost("/api/AdicionarDespesa")]
        [Produces("application/json")]
        public async Task<IActionResult> AdicionarDespesa(Despesa despesa)
        {
            await _IDespesaService.AddDespesa(despesa);
            return CreatedAtAction(nameof(ObterDespesa), new { id = despesa.Id }, despesa);
        }

        [HttpPut("/api/AtualizarDespesa")]
        [Produces("application/json")]
        public async Task<IActionResult> AtualizarDespesa(Despesa despesa)
        {
            var despesaExistente = await _IDespesa.GetEntityById(despesa.Id);
            if (despesaExistente == null)
            {
                return NotFound();
            }

            await _IDespesaService.UpdateDespesa(despesa);
            return NoContent();
        }

        [HttpGet("/api/ObterDespesa")]
        [Produces("application/json")]
        public async Task<IActionResult> ObterDespesa(int id)
        {
            var despesa = await _IDespesa.GetEntityById(id);
            if (despesa == null)
            {
                return NotFound();
            }
            return Ok(despesa);
        }

        [HttpDelete("/api/DeleteDespesa")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteDespesa(int id)
        {
            var despesa = await _IDespesa.GetEntityById(id);
            if (despesa == null)
            {
                return NotFound();
            }

            await _IDespesa.Delete(despesa);
            return NoContent();
        }
    }
}
