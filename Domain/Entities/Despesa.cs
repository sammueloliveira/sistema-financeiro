using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
   
        [Table("Despesa")]
        public class Despesa 
        {
            public int Id { get; set; }

            [Display(Name = "Nome")]
            public string? Nome { get; set; }
            public decimal Valor { get; set; }
            public int Mes { get; set; }
            public int Ano { get; set; }

            public EnumTipoDespesa TipoDespesa { get; set; }

            public DateTime DataCadastro { get; set; }

            public DateTime DataAlteracao { get; set; }

            public DateTime DataPagamento { get; set; }

            public DateTime DataVencimento { get; set; }

            public bool Pago { get; set; }

            public bool DespesaAntrasada { get; set; }

            [ForeignKey("Categoria")]
            public int IdCategoria { get; set; }
            public Categoria? Categoria { get; set; }
        }
    
}
