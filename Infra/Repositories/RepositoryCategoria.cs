using Domain.Entities;
using Domain.Interfaces;
using Infra.Infra;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class RepositoryCategoria : RepositoryGeneric<Categoria>, ICategoria
    {
        public RepositoryCategoria(Contexto contexto) : base(contexto)
        {
        }

        public async Task<IList<Categoria>> ListarCategoriasUsuario(string emailUsuario)
        {
            return await
                (from s in _contexto.SistemaFinanceiro
                 join c in _contexto.Categoria on s.Id equals c.IdSistema
                 join us in _contexto.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                 where us.EmailUsuario.Equals(emailUsuario) && us.SistemaAtual
                 select c).AsNoTracking().ToListAsync();
        }
    }
}
