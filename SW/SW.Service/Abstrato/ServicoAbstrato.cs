using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SW.Domain.Base;
using SW.Domain.Interfaces.Repositorio.Abstrato;

namespace SW.Service.Abstrato
{
    public class ServicoAbstrato<TEntity, TKey, TRepository> : IServicoAbstrato<TEntity, TKey>
        where TEntity : EntidadeBase
        where TRepository : IRepositorioAbstrato<TEntity, TKey>
    {
        #region Properties

        protected TRepository Repositorio;

        #endregion

        #region Constructor

        public ServicoAbstrato(TRepository repositorio)
        {
            this.Repositorio = repositorio;
        }

        #endregion

        #region Leitura

        public TEntity FindById(TKey key)
        {
            return this.Repositorio.FindById(key);
        }

        public TEntity FirstOrDefault(params Expression<Func<TEntity, bool>>[] parametros)
        {
            return this.Repositorio.FirstOrDefault(parametros);
        }

        public IQueryable<TEntity> FindAll()
        {
            return this.Repositorio.FindAll();
        }

        public IQueryable<TEntity> FindAll(params Expression<Func<TEntity, bool>>[] parametros)
        {
            return this.Repositorio.FindAll(parametros);
        }

        #endregion

        #region Escrita

        public IServicoAbstrato<TEntity, TKey> Insert(TEntity entidade)
        {
            this.Repositorio.Insert(entidade);
            return this;
        }

        public IServicoAbstrato<TEntity, TKey> Update(TEntity entidade)
        {
            this.Repositorio.Update(entidade);
            return this;
        }

        public IServicoAbstrato<TEntity, TKey> Delete(TEntity entidade)
        {
            this.Repositorio.Delete(entidade);
            return this;
        }

        public IServicoAbstrato<TEntity, TKey> Delete(TKey key)
        {
            TEntity entitie = FindById(key);
            if (entitie != null)
            {
                this.Repositorio.Delete(entitie);
            }
            return this;
        }

        public IServicoAbstrato<TEntity, TKey> Save()
        {
            Repositorio.Save();
            return this;
        }

        #endregion

        #region Metodos

        protected IQueryable<TEntity> AplicarParametros(IQueryable<TEntity> query
            , IEnumerable<Expression<Func<TEntity, bool>>> parametros)
        {
            return parametros.Aggregate(query, (current, c) => current.Where(c));
        }

        #endregion
    }
}
