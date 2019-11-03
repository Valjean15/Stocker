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
        private bool Disposed;

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
        /// <param name="Model">
        ///     Entidad a creare
        /// </param>
        /// <param name="CancellationToken">
        ///     Se utiliza para propagar notificaciones que la operación debe ser cancelada
        /// </param>
        public async Task CreateAsync(TEntity Model, CancellationToken CancellationToken)
        {
            ValidateState(Model, CancellationToken);
            Context.Add(Model);
            await SaveChanges(CancellationToken); 
        }

        /// <summary>
        ///     Actualizacion de una nueva entidad de forma asincrona
        /// </summary>
        /// <param name="Model">
        ///     Entidad a actualizar
        /// </param>
        /// <param name="CancellationToken">
        ///     Se utiliza para propagar notificaciones que la operación debe ser cancelada
        /// </param>
        public async Task UpdateAsync(TEntity Model, CancellationToken CancellationToken)
        {
            ValidateState(Model, CancellationToken);
            Context.Attach(Model);
            Context.Update(Model);

            try
            {
                await SaveChanges(CancellationToken);
            }
            catch (DbUpdateConcurrencyException Exception)
            {
                throw Exception;
            }
        }

        /// <summary>
        ///     Borrado de una nueva entidad de forma asincrona
        /// </summary>
        /// <param name="Model">
        ///     Entidad a borrar
        /// </param>
        /// <param name="CancellationToken">
        ///     Se utiliza para propagar notificaciones que la operación debe ser cancelada
        /// </param>
        public async Task DeleteAsync(TEntity Model, CancellationToken CancellationToken)
        {
            ValidateState(Model, CancellationToken);
            Context.Remove(Model);

            try
            {
                await SaveChanges(CancellationToken);
            }
            catch (DbUpdateConcurrencyException Exception)
            {
                throw Exception;
            }
        }

        /// <summary>
        ///     Realiza busqueda por llave primaria
        /// </summary>
        /// <param name="Key">
        ///     Valor a buscar
        /// </param>
        /// <param name="CancellationToken">
        ///     Se utiliza para propagar notificaciones que la operación debe ser cancelada
        /// </param>
        public async Task<TEntity> FindByKey(TKey Key, CancellationToken CancellationToken)
            => await Entities.FirstOrDefaultAsync(Model => Model.Id.Equals(Key), CancellationToken);

        /// <summary>
        ///     Liberacion de Recursos
        /// </summary>
        public void Dispose() => Disposed = true;

        /// <summary>
        ///     Accion de guardar.
        /// </summary>
        /// <param name="CancellationToken">
        ///     El <see cref="CancellationToken "/> se usa para propagar notificaciones de que la operación debe cancelarse.
        /// </param>
        /// <returns>
        ///     El <see cref="Task" /> que representa la operación asíncrona.
        /// </returns>
        private async Task SaveChanges(CancellationToken CancellationToken)
        {
            if (AutoSaveChanges)
                await Context.SaveChangesAsync(CancellationToken);
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
        private void ValidateState(TEntity Model, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (Disposed) throw new ObjectDisposedException(GetType().Name);
            if (Model is null) throw new ArgumentNullException(Model.GetType().Name);
        }
    }
}
