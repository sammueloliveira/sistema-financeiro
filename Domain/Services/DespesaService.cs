using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfacesServices;

namespace Domain.Services
{
    public class DespesaService : IDespesaService
    {
        private readonly IDespesa _despesa;
        public DespesaService(IDespesa despesa)
        {
            _despesa = despesa;
        }
    
        public async Task AddDespesa(Despesa despesa)
        {
            var data = DateTime.Now;
            despesa.DataCadastro = data;
            despesa.DataAlteracao = data;
            despesa.Ano = data.Year;
            despesa.Mes = data.Month;

            await _despesa.Add(despesa);
        }

        public async Task UpdateDespesa(Despesa despesa)
        {
            var data = DateTime.Now;
            despesa.DataAlteracao = data;

            if(despesa.Pago)
            {
                despesa.DataPagamento = data;
            }

            await _despesa.Update(despesa);
        }
    }
}
