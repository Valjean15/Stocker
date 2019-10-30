namespace Repository.Store
{
    using System;
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
    public interface IEntityStore<TEntity, Tkey> : IDisposable
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
        Task<TEntity> FindByKey(Tkey key, CancellationToken cancellationToken);
    }
}
