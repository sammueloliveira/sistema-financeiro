using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfacesServices;

namespace Domain.Services
{
    public class ServiceDespesa : IServiceDespesa
    {
        private readonly IDespesa _IDespesa;
        public ServiceDespesa(IDespesa iDespesa)
        {
            _IDespesa = iDespesa;
        }
    
        public async Task AddDespesa(Despesa despesa)
        {
            var data = DateTime.Now;
            despesa.DataCadastro = data;
            despesa.DataAlteracao = data;
            despesa.Ano = data.Year;
            despesa.Mes = data.Month;

            await _IDespesa.Add(despesa);
        }

        public async Task UpdateDespesa(Despesa despesa)
        {
            var data = DateTime.Now;
            despesa.DataAlteracao = data;

            if(despesa.Pago)
            {
                despesa.DataPagamento = data;
            }

            await _IDespesa.Update(despesa);
        }
    }
}
