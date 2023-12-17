using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Categoria 
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [ForeignKey("SistemaFinanceiro")]
        public int IdSistema { get; set; }
        public SistemaFinanceiro? SistemaFinanceiro { get; set; }
    }
}
