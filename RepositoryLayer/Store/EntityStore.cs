namespace Repository.Store
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Models.Interfaces;

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
    public abstract class EntityStore<TEntity, TContext, TKey> : IEntityStore<TEntity, TKey>, IDbContext<TContext>
        where TEntity : class, IEntityBase<TKey>
        where TKey : IEquatable<TKey>
        where TContext : DbContext
    {

        #region Variables

        /// <summary>
        ///     Indica si el store ya fue eliminado
        /// </summary>
        private bool _Disposed;

        /// <summary>
        /// <para> 
        ///     Indica si al final de cada operacion realizara <see cref="DbContext.SaveChanges(bool)"/>
        /// </para>
        /// <para>
        ///     Valor por defecto es <see langword="true"/>
        /// </para>
        /// </summary>
        private bool AutoSaveChanges { get; set; } = true;

        /// <summary>
        ///     Contexto a utilizar en el Store
        /// </summary>
        public TContext Context { get; }

        #endregion

        /// <summary>
        ///     Constructor base de la entidad
        /// </summary>
        /// <param name="Context">
        ///     Contexto a utilizar en el Store
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="Context"/> es un valor nulo
        /// </exception>
        protected EntityStore(TContext Context)
        {
            if (Context is null)
                throw new ArgumentNullException();

            this.Context = Context;
        }

        /// <summary>
        ///     Una propiedad de navegación para las entidades que contiene este Store.
        /// </summary>
        protected IQueryable<TEntity> Entities => Context.Set<TEntity>();

        /// <summary>
        ///     Creacion de una nueva entidad de forma asincrona
        /// </summary>
        /// <param name="entity">
        ///     Entidad a creare
        /// </param>
        /// <param name="cancellationToken">
        ///     Se utiliza para propagar notificaciones que la operación debe ser cancelada
        /// </param>
        public async Task CreateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            ValidateState(entity, cancellationToken);
            Context.Add(entity);
            await SaveChanges(cancellationToken); 
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
        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            ValidateState(entity, cancellationToken);
            Context.Attach(entity);
            Context.Update(entity);

            try
            {
                await SaveChanges(cancellationToken);
            }
            catch (DbUpdateConcurrencyException exception)
            {
                throw exception;
            }
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
        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            ValidateState(entity, cancellationToken);
            Context.Remove(entity);

            try
            {
                await SaveChanges(cancellationToken);
            }
            catch (DbUpdateConcurrencyException exception)
            {
                throw exception;
            }
        }

        /// <summary>
        ///     Realiza busqueda por llave primaria
        /// </summary>
        /// <param name="key">
        ///     Valor a buscar
        /// </param>
        /// <param name="cancellationToken">
        ///     Se utiliza para propagar notificaciones que la operación debe ser cancelada
        /// </param>
        public async Task<TEntity> FindByKey(TKey key, CancellationToken cancellationToken)
            => await Entities.FirstOrDefaultAsync(entity => entity.Id.Equals(key), cancellationToken);

        /// <summary>
        ///     Liberacion de Recursos
        /// </summary>
        public void Dispose() => _Disposed = true;

        /// <summary>
        ///     Accion de guardar.
        /// </summary>
        /// <param name="cancellationToken">
        ///     El <see cref="CancellationToken "/> se usa para propagar notificaciones de que la operación debe cancelarse.
        /// </param>
        /// <returns>
        ///     El <see cref="Task" /> que representa la operación asíncrona.
        /// </returns>
        private async Task SaveChanges(CancellationToken cancellationToken)
        {
            if (AutoSaveChanges)
                await Context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        ///     Realiza validacione generales para ejecuciones de las operaciones
        ///     del Store
        /// </summary>
        /// <param name="cancellationToken">
        ///     Token de cancelacion
        /// </param>
        /// <exception cref="CancellationToken.ThrowIfCancellationRequested">
        ///     Excepcion lanzada cuando el <see cref="CancellationToken"/> indica que la operacion ha sido cancelada
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     Excepcion lanzada cuando se indica que el <see cref="EntityStore{TEntity, TContext, TKey}"/> fue liberado
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     Excepcion lanzada cuando la <see cref="TEntity"/> a interactuar es <see langword="null"/>
        /// </exception>
        private void ValidateState(TEntity entity, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (_Disposed) throw new ObjectDisposedException(GetType().Name);
            if (entity is null) throw new ArgumentNullException(entity.GetType().Name);
        }
    }
}
