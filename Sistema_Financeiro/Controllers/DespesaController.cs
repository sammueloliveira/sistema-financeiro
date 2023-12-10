using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfacesServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sistema_Financeiro.Controllers
{
    [Route("api/despesa")]
    [ApiController]
    [Authorize]
    public class DespesaController : ControllerBase
    {
        private readonly IDespesa _despesa;
        private readonly IDespesaService _despesaService;

        public DespesaController(IDespesa despesa, IDespesaService despesaService)
        {
            _despesa = despesa;
            _despesaService = despesaService;
        }

        [HttpGet("listar-despesas-usuario")]
        [Produces("application/json")]
        public async Task<IActionResult> ListarDespesasUsuario([FromQuery] string emailUsuario)
        {
            var despesas = await _despesa.ListarDespesasUsuario(emailUsuario);

            return Ok(despesas);
        }


        [HttpPost("adicionar-despesa")]
        [Produces("application/json")]
        public async Task<IActionResult> AdicionarDespesa(Despesa despesa)
        {
            await _despesaService.AddDespesa(despesa);

            return CreatedAtAction(nameof(ObterDespesa), new { id = despesa.Id }, despesa);
        }

        [HttpPut("atualizar-despesa")]
        [Produces("application/json")]
        public async Task<IActionResult> AtualizarDespesa(Despesa despesa)
        {
            var despesaExistente = await _despesa.GetEntityById(despesa.Id);

            if (despesaExistente == null)
            {
                return NotFound();
            }

            await _despesaService.UpdateDespesa(despesa);

            return NoContent();
        }

        [HttpGet("obter-despesa")]
        [Produces("application/json")]
        public async Task<IActionResult> ObterDespesa(int id)
        {
            var despesa = await _despesa.GetEntityById(id);
            if (despesa == null)
            {
                return NotFound();
            }
            return Ok(despesa);
        }

        [HttpDelete("delete-despesa")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteDespesa(int id)
        {
            var despesa = await _despesa.GetEntityById(id);
            if (despesa == null)
            {
                return NotFound();
            }

            await _despesa.Delete(despesa);
            return NoContent();
        }
    }
}
