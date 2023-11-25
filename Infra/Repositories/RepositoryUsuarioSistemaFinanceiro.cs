using Domain.Entities;
using Domain.Interfaces;
using Infra.Infra;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class RepositoryUsuarioSistemaFinanceiro : RepositoryGeneric<UsuarioSistemaFinanceiro>, IUsuarioSistemaFinanceiro
    {
        public RepositoryUsuarioSistemaFinanceiro(Contexto contexto) : base(contexto)
        {
        }

        public async Task<IList<UsuarioSistemaFinanceiro>> ListarUsuariosSistema(int IdSistema)
        {
            return await
                _contexto.UsuarioSistemaFinanceiro
                .Where(s => s.IdSistema == IdSistema).AsNoTracking()
                .ToListAsync();
        }

        public async Task<UsuarioSistemaFinanceiro> ObterUsuarioPorEmail(string emailUsuario)
        {
            return await
                _contexto.UsuarioSistemaFinanceiro.AsNoTracking().FirstOrDefaultAsync(x => x.EmailUsuario.Equals(emailUsuario));
        }

        public async Task RemoveUsuarios(List<UsuarioSistemaFinanceiro> usuarios)
        {
            _contexto.UsuarioSistemaFinanceiro
                .RemoveRange(usuarios);

            await _contexto.SaveChangesAsync();
        }
    }
}
