using SW.Domain.Base;

namespace SW.Service.Abstrato
{
    public interface IServicoAbstratoEscrita<TEntity, TKey>
        where TEntity : EntidadeBase
    {
        IServicoAbstrato<TEntity, TKey> Insert(TEntity entidade);

        IServicoAbstrato<TEntity, TKey> Update(TEntity entidade);

        IServicoAbstrato<TEntity, TKey> Delete(TEntity entidade);

        IServicoAbstrato<TEntity, TKey> Delete(TKey key);

        IServicoAbstrato<TEntity, TKey> Save();
    }
}
