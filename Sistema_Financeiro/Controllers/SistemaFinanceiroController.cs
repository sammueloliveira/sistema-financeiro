using APIs.Models.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfacesServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/sistema-financeiro")]
    [ApiController]
    [Authorize]
    public class SistemaFinanceirosController : ControllerBase
    {
        private readonly ISistemaFinanceiro _sistemaFinanceiro;
        private readonly ISistemaFinanceiroService _sistemaFinanceiroService;
        private readonly IMapper _mapper;
        public SistemaFinanceirosController(ISistemaFinanceiro sistemaFinanceiro,
            ISistemaFinanceiroService sistemaFinanceiroServico, IMapper mapper)
        {
            _sistemaFinanceiro = sistemaFinanceiro;
            _sistemaFinanceiroService = sistemaFinanceiroServico;
            _mapper = mapper;
        }

        [HttpGet("lista-sistemas-usuario")]
        [Produces("application/json")]
        public async Task<object> ListaSistemasUsuario(string emailUsuario)
        {
            return await _sistemaFinanceiro.ListaSistemasUsuario(emailUsuario);
        }

        [HttpPost("adicionar-sistema-financeiro")]
        [Produces("application/json")]
        public async Task<object> AdicionarSistemaFinanceiro(SistemaFinanceiroDTO sistemaFinanceiroDto)
        {
            var sistemaFinanceiro = _mapper.Map<SistemaFinanceiro>(sistemaFinanceiroDto);
            await _sistemaFinanceiroService.AddSistemaFinanceiro(sistemaFinanceiro);

            return Ok(sistemaFinanceiro);
        }

        [HttpPut("atualizar-sistema-financeiro")]
        [Produces("application/json")]
        public async Task<object> AtualizarSistemaFinanceiro(int id, SistemaFinanceiroDTO sistemaFinanceiroDto)
        {
            if(id != sistemaFinanceiroDto.Id)
            {
                return BadRequest();
            }

            var sistemaFinanceiro = _mapper.Map<SistemaFinanceiro>(sistemaFinanceiroDto);
            await _sistemaFinanceiroService.UpdateSistemaFinanceiro(sistemaFinanceiro);

            return Ok(sistemaFinanceiro);
        }


        [HttpGet("obter-sistema-financeiro")]
        [Produces("application/json")]
        public async Task<object> ObterSistemaFinanceiro(int id)
        {
            return await _sistemaFinanceiro.GetEntityById(id);
        }


        [HttpDelete("delete-sistema-financeiro")]
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