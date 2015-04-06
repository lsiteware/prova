using System;
using System.Linq;
using System.Linq.Expressions;
using SW.Domain.Base;

namespace SW.Domain.Interfaces.Repositorio.Abstrato
{
    public interface IRepositorioAbstratoLeitura<TEntity, in TKey>
    where TEntity : EntidadeBase
    {
        TEntity FindById(TKey key);

        TEntity FirstOrDefault(params Expression<Func<TEntity, bool>>[] parameters);

        IQueryable<TEntity> FindAll();

        IQueryable<TEntity> FindAll(params Expression<Func<TEntity, bool>>[] parameters);
    }
}
