using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models.DTOs
{
    public class UsuarioSistemaFinanceiroDTO
    {
        public int Id { get; set; }
        public string? EmailUsuario { get; set; }
        public bool Administrador { get; set; }
        public bool SistemaAtual { get; set; }
        public int IdSistema { get; set; }
       
    }
}
