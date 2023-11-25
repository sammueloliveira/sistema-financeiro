using Domain.Entities;
using Domain.Interfaces;
using Infra.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class RepositoryDespesa : RepositoryGeneric<Despesa>, IDespesa
    {
        public RepositoryDespesa(Contexto contexto) : base(contexto)
        {
        }

        public async Task<IList<Despesa>> ListarDespesasUsuario(string emailUsuario)
        {
            return await
               (from s in _contexto.SistemaFinanceiro
                join c in _contexto.Categoria on s.Id equals c.IdSistema
                join us in _contexto.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                join d in _contexto.Despesa on c.Id equals d.IdCategoria
                where us.EmailUsuario.Equals(emailUsuario) && s.Mes == d.Mes && s.Ano == d.Ano
                select d).AsNoTracking().ToListAsync();
        }

        public async Task<IList<Despesa>> ListarDespesasUsuarioNaoPagasMesesAnterior(string emailUsuario)
        {
            return await
               (from s in _contexto.SistemaFinanceiro
                join c in _contexto.Categoria on s.Id equals c.IdSistema
                join us in _contexto.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                join d in _contexto.Despesa on c.Id equals d.IdCategoria
                where us.EmailUsuario.Equals(emailUsuario) && d.Mes < DateTime.Now.Month && !d.Pago
                select d).AsNoTracking().ToListAsync();
        }
    }
}
