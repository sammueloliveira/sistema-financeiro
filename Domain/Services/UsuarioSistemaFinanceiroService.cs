using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfacesServices;

namespace Domain.Services
{
    public class UsuarioSistemaFinanceiroService : IUsuarioSistemaFinanceiroService
    {
        private readonly IUsuarioSistemaFinanceiro _IUsuarioSistemaFinanceiro;
        public UsuarioSistemaFinanceiroService(IUsuarioSistemaFinanceiro iUsuarioSistemaFinanceiro)
        {
            _IUsuarioSistemaFinanceiro = iUsuarioSistemaFinanceiro;
        }

        public async Task CadastrarUsuarioNoSistema(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro)
        {
            await _IUsuarioSistemaFinanceiro.Add(usuarioSistemaFinanceiro);
        }
    }
}
