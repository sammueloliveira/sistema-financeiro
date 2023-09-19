using Domain.Entities;

namespace Domain.InterfacesServices
{
    public interface IUsuarioSistemaFinanceiroService
    {
        Task CadastrarUsuarioNoSistema(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro);
    }
}
