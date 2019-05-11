namespace RepositoryLayer.Store
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Models;

    /// <summary>
    ///     Implementacion de un Store para las entidades de base de datos
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Tipo de la entidad a interacturar con el Store
    /// </typeparam>
    /// <typeparam name="TContext">
    ///     Tipo del contexto a interactuar
    /// </typeparam>
    /// <typeparam name="TKey">
    ///     Tipo de la llave primaria de la entidad
    /// </typeparam>
    public class EntityStore<TEntity, TContext, TKey> : IEntityStore<TEntity, TKey>, IDbContext<TContext>
        where TEntity : class, IEntityBase<TKey>
        where TKey : IEquatable<TKey>
        where TContext : DbContext
    {

        /// <summary>
        ///     Constructor base de la entidad
        /// </summary>
        /// <param name="context">
        ///     Contexto a utilizar en el Store
        /// </param>
        public EntityStore(TContext context)
        {
            Context = context;
        }

        /// <summary>
        ///     Contexto a utilizar en el Store
        /// </summary>
        public TContext Context { get; }

        /// <summary>
        ///     Creacion de una nueva entidad de forma asincrona
        /// </summary>
        /// <param name="entity">
        ///     Entidad a creare
        /// </param>
        /// <param name="cancellationToken">
        ///     Se utiliza para propagar notificaciones que la operación debe ser cancelada
        /// </param>
        public Task CreateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Actualizacion de una nueva entidad de forma asincrona
        /// </summary>
        /// <param name="entity">
        ///     Entidad a actualizar
        /// </param>
        /// <param name="cancellationToken">
        ///     Se utiliza para propagar notificaciones que la operación debe ser cancelada
        /// </param>
        public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Borrado de una nueva entidad de forma asincrona
        /// </summary>
        /// <param name="entity">
        ///     Entidad a borrar
        /// </param>
        /// <param name="cancellationToken">
        ///     Se utiliza para propagar notificaciones que la operación debe ser cancelada
        /// </param>
        public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Liberacion de Recursos
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
