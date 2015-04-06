using System;
using System.Linq;
using System.Linq.Expressions;
using SW.Domain.Base;

namespace SW.Service.Abstrato
{
    public interface IServicoAbstratoLeitura<TEntity, in TKey>
        where TEntity : EntidadeBase
    {
        TEntity FindById(TKey key);

        TEntity FirstOrDefault(params Expression<Func<TEntity, bool>>[] parametros);

        IQueryable<TEntity> FindAll();

        IQueryable<TEntity> FindAll(params Expression<Func<TEntity, bool>>[] parametros);
    }
}
