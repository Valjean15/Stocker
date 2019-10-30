using System;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Context;
using Models.Interfaces;

namespace Repository.Store
{
    /// <summary>
    ///     Store de contexto del contexto <see cref="StockerContext"/> y de entidades que
    ///     hereden de <see cref="IEntityBase{int}"/>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class StockerStore<TEntity> : EntityStore<TEntity, StockerContext, int>, IStockerStore<TEntity>
        where TEntity : class, IEntityBase<int>
    {
        /// <summary>
        ///     Constructor del store
        /// </summary>
        /// <param name="context">
        ///     Contexto de consultas
        /// </param>
        public StockerStore(StockerContext context) : base(context) { }

        /// <summary>
        ///     Obtiene todos los elementos del store
        /// </summary>
        public IQueryable<TEntity> Items => Entities;

        /// <summary>
        ///     Realiza busqueda en base a una condicion
        /// </summary>
        /// <param name="condition">
        ///     Condicion de busqueda
        /// </param>
        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> condition)
            => Entities.Where(condition);
    }
}
