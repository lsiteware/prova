using SW.Domain.Base;

namespace SW.Service.Abstrato
{
    public interface IServicoAbstrato<TEntity, TKey> : IServicoAbstratoLeitura<TEntity, TKey>, IServicoAbstratoEscrita<TEntity, TKey>
        where TEntity : EntidadeBase
    {
    }
}
