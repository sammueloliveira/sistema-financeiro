using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfacesServices;

namespace Domain.Services
{
    public class SistemaFinanceiroService : ISistemaFinanceiroService
    {
        private readonly ISistemaFinanceiro _sistemaFinanceiro;
        public SistemaFinanceiroService(ISistemaFinanceiro SistemaFinanceiro)
        {
            _sistemaFinanceiro = SistemaFinanceiro;
        }

        public async Task AddSistemaFinanceiro(SistemaFinanceiro sistema)
        {
            var data = DateTime.Now;
            sistema.DiaFechamento = 1;
            sistema.Ano = data.Year;
            sistema.Mes = data.Month;
            sistema.AnoCopia = data.Year;
            sistema.Mes = data.Month;
            sistema.GerarCopiaDespesa = true;

            await _sistemaFinanceiro.Add(sistema);
        }

        public async Task UpdateSistemaFinanceiro(SistemaFinanceiro sistema)
        {
            var data = DateTime.Now;
            sistema.DiaFechamento = 1;

            await _sistemaFinanceiro.Update(sistema);
        }
    }
}
