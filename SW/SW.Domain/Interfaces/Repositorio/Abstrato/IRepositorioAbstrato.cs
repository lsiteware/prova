using SW.Domain.Base;

namespace SW.Domain.Interfaces.Repositorio.Abstrato
{
    public interface IRepositorioAbstrato<TEntity, TKey> : IRepositorioAbstratoLeitura<TEntity, TKey>, IRepositorioAbstratoEscrita<TEntity, TKey>
        where TEntity : EntidadeBase
    {
    }
}
