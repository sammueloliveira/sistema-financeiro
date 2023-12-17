using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int IdSistema { get; set; }
       
    }
}
