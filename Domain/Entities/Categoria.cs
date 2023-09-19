using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Categoria : Base
    {
        [ForeignKey("SistemaFinanceiro")]
        public int IdSistema { get; set; }
        public virtual SistemaFinanceiro SistemaFinanceiro { get; set; }
    }
}
