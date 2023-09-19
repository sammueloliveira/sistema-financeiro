using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class UsuarioSistemaFinanceiro
    {
        public int Id { get; set; }
        public string EmailUsuario { get; set; }
        public bool Administrador { get; set; }
        public bool SistemaAtual { get; set; }

        [ForeignKey("SistemaFinanceiro")]
        public int IdSistema { get; set; }
        public virtual SistemaFinanceiro SistemaFinanceiro { get; set; }
    }
}
