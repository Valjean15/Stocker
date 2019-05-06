using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace sis.DAL.Repositories.Base
{
    /// <summary>
    /// Define un CRUD base para implementar en repositorios que acceden a datos de un contexto especifico
    /// </summary>
    /// <typeparam name="TEntity">Entidad del modelo de datos</typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity : class
    {
        /// <summary>
        /// Indica si el repositorio ya fue liberado
        /// </summary>
        protected bool Disposed = false;

        /// <summary>
        /// Contexto de consultas
        /// </summary>
        protected readonly DbContext Context;

        /// <summary>
        /// Constructor base del repositorio
        /// </summary>
        /// <param name="context">Contexto</param>
        public BaseRepository(DbContext context) => Context = context;

        /// <inheritdoc/>
        public DbSet<TEntity> GetDbSet() => Context.Set<TEntity>();

        #region Operaciones Basicas

        /// <inheritdoc/>
        public virtual void Add(TEntity entity) => GetDbSet().Add(entity);

        /// <inheritdoc/>
        public virtual void Save()
        {
            var saveState = false;
            do
            {
                try
                {
                    Context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException concurrencyException)
                {
                    saveState = true;
                    var entry = concurrencyException.Entries.Single();
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                }
            }
            while (saveState);
        }

        /// <inheritdoc/>
        public virtual void Edit(TEntity entity) => Context.Entry(entity).State = EntityState.Modified;

        /// <inheritdoc/>
        public virtual void Delete(TEntity entity)
        {
            GetDbSet().Attach(entity);
            GetDbSet().Remove(entity);
        }

        #endregion

        #region Operaciones Compuestas

        /// <inheritdoc/>
        public void AddRange(IEnumerable<TEntity> entites) => GetDbSet().AddRange(entites);

        /// <inheritdoc/>
        public virtual void Patch(TEntity entity, IEnumerable<string> properties)
        {
            GetDbSet().Attach(entity);

            var entry = Context.Entry(entity);
            foreach (var property in properties)
                entry.Property(property).IsModified = true;
        }

        /// <inheritdoc/>
        public TEntity Delete(params object[] keyValues)
        {
            var entity = FindByKey(keyValues);
            if (entity == null) return null;
            Delete(entity);
            return entity;
        }

        /// <inheritdoc/>
        public void DeleteBy(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = FindBy(predicate).AsEnumerable();
            GetDbSet().RemoveRange(entities);
        }

        #endregion

        #region Busqueda

        /// <inheritdoc/>
        public virtual IQueryable<TEntity> GetAll() => GetDbSet();

        /// <inheritdoc/>
        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate) => GetDbSet().Where(predicate);

        /// <inheritdoc/>
        public TEntity FirstBy(Expression<Func<TEntity, bool>> predicate) => FirstOrDefault(predicate);

        /// <inheritdoc/>
        public bool Any(Expression<Func<TEntity, bool>> predicate) => GetDbSet().Any(predicate);

        /// <inheritdoc/>
        public TEntity FindByKey(params object[] keyValues) => GetDbSet().Find(keyValues);

        /// <inheritdoc/>
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate) => GetDbSet().FirstOrDefault(predicate);

        #endregion

        #region IDisposable

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed && disposing)
                Context?.Dispose();

            Disposed = true;
        }

        #endregion
    }
}