namespace Repository.Store
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using DataAccess.Context;
    using Models.Interfaces;

    /// <summary>
    ///     Store de contexto del contexto <see cref="StockerContext"/> y de entidades que
    ///     hereden de <see cref="IEntityBase{int}"/>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IStockerStore<TEntity> : IEntityStore<TEntity, int>, IDbContext<StockerContext>
        where TEntity : class, IEntityBase<int>
    {
        /// <summary>
        ///     Obtiene todas los registros del store
        /// </summary>
        IQueryable<TEntity> Items { get; }

        /// <summary>
        ///     Busca todas las entidades que cumplan con una condicion
        /// </summary>
        /// <param name="Condition">
        ///     Condicion a filtrar
        /// </param>
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> Condition);
    }
}
