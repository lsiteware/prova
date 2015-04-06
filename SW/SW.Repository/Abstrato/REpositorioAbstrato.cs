using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SW.Domain.Base;
using SW.Domain.Interfaces.Repositorio.Abstrato;

namespace SW.Repository.Abstrato
{
    public class RepositorioAbstrato<TEntity, TKey> : IRepositorioAbstrato<TEntity, TKey>
        where TEntity : EntidadeBase
    {
        #region Properties

        protected DbContext Contexto;

        protected DbSet<TEntity> Entidades
        {
            get { return Contexto.Set<TEntity>(); }
        }

        #endregion

        #region Constructor

        public RepositorioAbstrato(DbContext context)
        {
            Contexto = context;
        }

        #endregion

        #region Leitura

        public TEntity FindById(TKey key)
        {
            return Entidades.Find(key);
        }

        public TEntity FirstOrDefault(params Expression<Func<TEntity, bool>>[] parametros)
        {
            IQueryable<TEntity> query = Entidades.AsQueryable();
            query = AplicarParametros(query, parametros);
            return query.FirstOrDefault();
        }

        public IQueryable<TEntity> FindAll()
        {
            return Entidades;
        }

        public IQueryable<TEntity> FindAll(params Expression<Func<TEntity, bool>>[] parametrros)
        {
            var query = Entidades.AsQueryable();
            query = AplicarParametros(query, parametrros);
            return query;
        }

        #endregion

        #region Escrita

        public IRepositorioAbstrato<TEntity, TKey> Insert(TEntity entidade)
        {
            Entidades.Add(entidade);
            return this;
        }

        public IRepositorioAbstrato<TEntity, TKey> Update(TEntity entidade)
        {
            Entidades.Attach(entidade);
            Contexto.Entry(entidade).State = EntityState.Modified;
            return this;
        }

        public IRepositorioAbstrato<TEntity, TKey> Delete(TEntity entidade)
        {
            Entidades.Remove(entidade);
            return this;
        }

        public IRepositorioAbstrato<TEntity, TKey> Delete(TKey key)
        {
            var entitie = FindById(key);
            if (entitie != null)
            {
                Entidades.Remove(entitie);
            }
            return this;
        }

        public IRepositorioAbstrato<TEntity, TKey> Save()
        {
            Contexto.SaveChanges();
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
