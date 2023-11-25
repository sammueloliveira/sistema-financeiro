using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Categoria : Base
    {
        [ForeignKey("SistemaFinanceiro")]
        public int IdSistema { get; set; }
        public SistemaFinanceiro? SistemaFinanceiro { get; set; }
    }
}
