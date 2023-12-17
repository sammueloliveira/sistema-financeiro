using APIs.Models.DTOs;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public DespesaController(IDespesa despesa, IDespesaService despesaService, IMapper mapper)
        {
            _despesa = despesa;
            _despesaService = despesaService;
            _mapper = mapper;
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
        public async Task<IActionResult> AdicionarDespesa(DespesaDTO despesaDto)
        {
            var despesa = _mapper.Map<Despesa>(despesaDto);
            await _despesaService.AddDespesa(despesa);

            return Ok(despesa);
        }

        [HttpPut("atualizar-despesa")]
        [Produces("application/json")]
        public async Task<IActionResult> AtualizarDespesa(int id, DespesaDTO despesadto)
        {
           if(id != despesadto.Id)
           {
                return BadRequest();
           }

            var despesa = _mapper.Map<Despesa>(despesadto);
            await _despesa.Update(despesa);

            return Ok(despesa);

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
