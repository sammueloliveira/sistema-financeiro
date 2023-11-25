using Domain.Entities;
using Domain.Interfaces;
using Infra.Infra;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class RepositorySistemaFinanceiro : RepositoryGeneric<SistemaFinanceiro>, ISistemaFinanceiro
    {
        public RepositorySistemaFinanceiro(Contexto contexto) : base(contexto)
        {
        }

        public async Task<IList<SistemaFinanceiro>> ListaSistemasUsuario(string emailUsuario)
        {
            return await
               (from s in _contexto.SistemaFinanceiro
                join us in _contexto.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                where us.EmailUsuario.Equals(emailUsuario)
                select s).AsNoTracking().ToListAsync();
        }
    }
}
