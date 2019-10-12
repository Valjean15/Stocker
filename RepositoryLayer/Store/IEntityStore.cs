namespace RepositoryLayer.Store
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Models.Interfaces;

    /// <summary>
    ///     Comportamiento del Store de una entidad, solo contiene funcionalidades
    ///     basicas de gestion de datos
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Tipo de la entidad a gestionar
    /// </typeparam>
    /// <typeparam name="Tkey">
    ///     Tipo de la llave primaria de la entidad a gestionar
    /// </typeparam>
    internal interface IEntityStore<TEntity, Tkey> : IDisposable
        where TEntity : class, IEntityBase<Tkey>
        where Tkey : IEquatable<Tkey>
    {
        /// <summary>
        ///     Creacion de una nueva entidad de forma asincrona
        /// </summary>
        /// <param name="entity">
        ///     Entidad a creare
        /// </param>
        /// <param name="cancellationToken">
        ///     Se utiliza para propagar notificaciones que la operación debe ser cancelada
        /// </param>
        /// <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=netframework-4.8"/>
        Task CreateAsync(TEntity entity, CancellationToken cancellationToken);

        /// <summary>
        ///     Actualizacion de una nueva entidad de forma asincrona
        /// </summary>
        /// <param name="entity">
        ///     Entidad a actualizar
        /// </param>
        /// <param name="cancellationToken">
        ///     Se utiliza para propagar notificaciones que la operación debe ser cancelada
        /// </param>
        /// <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=netframework-4.8"/>
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);

        /// <summary>
        ///     Borrado de una nueva entidad de forma asincrona
        /// </summary>
        /// <param name="entity">
        ///     Entidad a borrar
        /// </param>
        /// <param name="cancellationToken">
        ///     Se utiliza para propagar notificaciones que la operación debe ser cancelada
        /// </param>
        /// <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=netframework-4.8"/>
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);

        /// <summary>
        ///     Busca una entidad por su llave primaria
        /// </summary>
        /// <param name="key">
        ///     Valor de la entidad a buscar
        /// </param>
        /// <param name="cancellationToken">
        ///     Se utiliza para propagar notificaciones que la operación debe ser cancelada
        /// </param>
        /// <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=netframework-4.8"/>
        Task<TEntity> FindByKey(Tkey key, CancellationToken cancellationToken);

        /// <summary>
        ///     Busca todas las entidades que cumplan con una condicion
        /// </summary>
        /// <param name="condition">
        ///     Condicion a filtrar
        /// </param>
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> condition);
    }
}
