using SW.Domain.Base;

namespace SW.Domain.Interfaces.Repositorio.Abstrato
{
    public interface IRepositorioAbstratoEscrita<TEntity, TKey>
        where TEntity : EntidadeBase
    {
        IRepositorioAbstrato<TEntity, TKey> Insert(TEntity entitie);

        IRepositorioAbstrato<TEntity, TKey> Update(TEntity entitie);

        IRepositorioAbstrato<TEntity, TKey> Delete(TEntity entitie);

        IRepositorioAbstrato<TEntity, TKey> Delete(TKey key);

        IRepositorioAbstrato<TEntity, TKey> Save();
    }
}
