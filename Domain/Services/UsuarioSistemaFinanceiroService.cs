using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfacesServices;

namespace Domain.Services
{
    public class UsuarioSistemaFinanceiroService : IUsuarioSistemaFinanceiroService
    {
        private readonly IUsuarioSistemaFinanceiro _usuarioSistemaFinanceiro;
        public UsuarioSistemaFinanceiroService(IUsuarioSistemaFinanceiro usuarioSistemaFinanceiro)
        {
            _usuarioSistemaFinanceiro = usuarioSistemaFinanceiro;
        }

        public async Task CadastrarUsuarioNoSistema(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro)
        {
            await _usuarioSistemaFinanceiro.Add(usuarioSistemaFinanceiro);
        }
    }
}
